using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;    
    public AudioClip deathSFX;
    private AudioSource audioSource;
    Animator animator;

    [SerializeField]
    private int _maxHealth = 100;

    public int MaxHealth 
    { 
        get 
        {
            return _maxHealth;
        }

        set 
        {
            _maxHealth = value;
       
        } 
    }

    [SerializeField]
    private int _health = 100;
    [SerializeField] 
    private BossHealthBar bossHealthBar;

    public int Health
    { 
        get 
        { 
            return _health; 
        } 
        set 
        {
            _health = value;

            if (bossHealthBar != null)
                bossHealthBar.SetHealth(_health, MaxHealth);

            if (_health <= 0)
                IsAlive = false;

            // Health deðiþince HealthBar güncelle
            PlayerController pc = GetComponent<PlayerController>();
            if (pc != null && pc.healthBarUI != null)
            {
                pc.healthBarUI.SetHealth(_health, MaxHealth);
            }
        } 
    }

    [SerializeField]
    private bool _isAlive = true;

    [SerializeField]
    private bool isInvincible = false;

   

    private float timeSinceHit = 0;
    public float invincibilityTime = 0.25f;

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set: " + value);

            if (!_isAlive && gameObject.CompareTag("Boss"))
            {
                WinScreenManager winManager = FindAnyObjectByType<WinScreenManager>();
                if (winManager != null)
                {
                    winManager.ShowWinScreen();
                }
            }

            // SADECE PLAYER için Game Over panelini göster
            if (!_isAlive && gameObject.CompareTag("Player"))
            {
                AudioSource src = GetComponent<AudioSource>();
                if (src != null && deathSFX != null)
                {
                    src.PlayOneShot(deathSFX);
                }
                GameOverManager manager = FindAnyObjectByType<GameOverManager>();
                if (manager != null)
                {
                    manager.ShowGameOver();
                }
            }
        }
    }



    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }
        set
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if(isInvincible) 
        { 
        if(timeSinceHit > invincibilityTime)
            {
                //görünmezligi kaldir
                isInvincible = false;
                timeSinceHit = 0;
            }

          timeSinceHit += Time.deltaTime;
        }
    }

    private IEnumerator FlashRed()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color originalColor = sr.color;
            sr.color = new Color(1f, 0.3f, 0.3f); 
            yield return new WaitForSeconds(0.1f);
            sr.color = originalColor;
        }
    }


    public bool Hit(int damage, Vector2 knockback)
    {
        if(IsAlive && !isInvincible) 
        {
            StartCoroutine(FlashRed());
            Health -= damage;
            isInvincible = true;


            animator.SetTrigger(AnimationStrings.hitTrigger);
            LockVelocity = true;
            damageableHit?.Invoke(damage, knockback);
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);

            return true;
        }

        return false;
    }

    public bool Heal(int healthRestore)
    {
        if (IsAlive && Health < MaxHealth)
        {
           int maxHeal = Mathf.Max(MaxHealth - Health, 0);
            int actualHeal = Mathf.Min(maxHeal, healthRestore);
            Health += actualHeal;
           CharacterEvents.characterHealed(gameObject, actualHeal);
            return true;
        }

        return false;
    }



}
