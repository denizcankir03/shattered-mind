using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public GameObject bossHealthBarBG;

    private void Start()
    {
        if (bossHealthBarBG != null)
            bossHealthBarBG.SetActive(false); // Baþlangýçta kapalý olsun
    }


    private void OnDestroy()
    {
        if (bossHealthBarBG != null)
            bossHealthBarBG.SetActive(false); // Boss yok olunca kapa
    }
}
