using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealthBar : MonoBehaviour
{
    public Image fillImage;
    public TMP_Text healthText;

    public void SetHealth(float current, float max)
    {
        fillImage.fillAmount = current / max;

        if (healthText != null)
            healthText.text = $"{(int)current} / {(int)max}";
    }
}
