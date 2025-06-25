using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;    // Ye�il dolan k�s�m
    [SerializeField] private TMP_Text healthText;  // Sa�l�k say�s� g�stergesi

    // Sa�l�k y�zdesini 0-1 aras�nda ayarla ve texti g�ncelle
    public void SetHealth(int currentHealth, int maxHealth)
    {
        float normalizedHealth = Mathf.Clamp01((float)currentHealth / maxHealth);
        fillImage.fillAmount = normalizedHealth;

        healthText.text = currentHealth + " / " + maxHealth;
    }
}
