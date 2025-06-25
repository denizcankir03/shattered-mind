using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]

public class PlayerController : MonoBehaviour
{
    public AudioClip attackSFX;
    public AudioClip jumpSFX;
    public AudioClip hitSFX;
    public AudioClip deathSFX;
    private AudioSource audioSource;
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float airWalkSpeed = 1.0f;
    public float jumpImpulse = 10f;
    Vector2 moveInput;
    TouchingDirections touchingDirections;
    public HealthBarUI healthBarUI;
    Damageable damageable;
   

    public float CurrentMoveSpeed
    {
        get
        {
            if (CanMove)
            {
                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    if (touchingDirections.IsGrounded)
                    {
                        if (IsRunning)
                        {
                            return runSpeed;
                        }
                        else
                        {
                            return walkSpeed;
                        }
                    }


                    else
                    {
                        
                        return airWalkSpeed;
                    }
                }
                else
                {
                    
                    return 0;
                }
            }
            else
            {
                
                return 0;
            }
            
        
        }
    }


    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving { get 
        {
            return _isMoving;
        } 
        private set 
        { 
           _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        } 
    }
    [SerializeField]
    private bool _isRunning = false;

    public bool IsRunning 
    { 
        get
        {
            return _isRunning;
        } 
        set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    public bool _isFacingRight = true;

    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        private set
        {
            if (_isFacingRight != value)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x) * (value ? 1 : -1);
                transform.localScale = scale;
            }

            _isFacingRight = value;
        }
    }




    public bool CanMove { get
        {
          return animator.GetBool(AnimationStrings.canMove);
        } 
    }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }

    }

    

    Rigidbody2D rb;
    Animator animator;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
        audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBarUI != null)
            healthBarUI.SetHealth(damageable.Health, damageable.MaxHealth);
    }

    private void FixedUpdate()
    {
        if(!damageable.LockVelocity)
            rb.linearVelocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.linearVelocity.y);

        animator.SetFloat(AnimationStrings.yVelocity, rb.linearVelocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if(IsAlive)
        {

            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        }else
        {
            IsMoving = false;
        }

    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight) 
        { 
         IsFacingRight = true;
        }
        else if(moveInput.x < 0 && IsFacingRight)
        {
         IsFacingRight= false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }else if(context.canceled)
        {
            IsRunning= false;
        }

    }

    public void OnJump(InputAction.CallbackContext context)
    { 
      
        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpImpulse);
            audioSource.PlayOneShot(jumpSFX);
        }
    
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
            audioSource.PlayOneShot(attackSFX);
        }


    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.linearVelocity = new Vector2(knockback.x, rb.linearVelocity.y + knockback.y);
        audioSource.PlayOneShot(hitSFX);
    }

}
