using UnityEngine;

public class BossAreaTrigger : MonoBehaviour
{
    public GameObject bossHealthBarBG;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (bossHealthBarBG != null)
                bossHealthBarBG.SetActive(true); // Player boss alan�na girdi, bar a�
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (bossHealthBarBG != null)
                bossHealthBarBG.SetActive(false); // Player boss alan�ndan ��kt�, bar kapat
        }
    }
}
