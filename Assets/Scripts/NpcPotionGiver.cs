using UnityEngine;
using TMPro;

public class NpcPotionGiver : MonoBehaviour
{
    public int healthRestore = 20;
    public float interactDistance = 2f;
    public KeyCode interactKey = KeyCode.E;

    private Transform player;
    public GameObject interactTextUI; 

    void Start()
    {
       

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (interactTextUI != null)
            interactTextUI.SetActive(false); // baþlangýçta kapalý
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(player.position, transform.position);

            if (distance <= interactDistance)
            {
                if (interactTextUI != null)
                    interactTextUI.SetActive(true); // göster

                if (Input.GetKeyDown(interactKey))
                    GivePotion();
            }
            else
            {
                if (interactTextUI != null)
                    interactTextUI.SetActive(false); // uzaksa gizle
            }
        }
    }

    void GivePotion()
    {
        Damageable damageable = player.GetComponent<Damageable>();

        if (damageable != null)
        {
            bool wasHealed = damageable.Heal(healthRestore);

            if (wasHealed)
            {
                Debug.Log("NPC: Potion verdi!");

                if (interactTextUI != null)
                    interactTextUI.SetActive(false);

                // NPC bir daha iksir vermesin:
                this.enabled = false;

                // Ayrýca yazý sonsuza kadar gizli kalsýn:
                interactTextUI = null;
            }
        }
    }

}
