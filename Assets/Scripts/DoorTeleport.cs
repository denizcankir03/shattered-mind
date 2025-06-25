using UnityEngine;
using TMPro;

public class DoorTeleport : MonoBehaviour
{
    public Transform teleportTarget;
    public KeyCode interactKey = KeyCode.E;
    public GameObject interactTextUI; 

    private bool isPlayerNearby = false;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (interactTextUI != null)
            interactTextUI.SetActive(false); // Baþlangýçta gizli
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(interactKey))
        {
            player.position = teleportTarget.position;

            if (interactTextUI != null)
                interactTextUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;

            if (interactTextUI != null)
                interactTextUI.SetActive(true); // Yazýyý göster
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (interactTextUI != null)
                interactTextUI.SetActive(false); // Yazýyý gizle
        }
    }
}
