using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;    // Yeþil dolan kýsým
    [SerializeField] private TMP_Text healthText;  // Saðlýk sayýsý göstergesi

    // Saðlýk yüzdesini 0-1 arasýnda ayarla ve texti güncelle
    public void SetHealth(int currentHealth, int maxHealth)
    {
        float normalizedHealth = Mathf.Clamp01((float)currentHealth / maxHealth);
        fillImage.fillAmount = normalizedHealth;

        healthText.text = currentHealth + " / " + maxHealth;
    }
}
