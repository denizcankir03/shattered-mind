using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public GameObject winScreenPanel;

    private void Start()
    {
        winScreenPanel.SetActive(false); // Ba�lang��ta g�r�nmez
    }

    public void ShowWinScreen()
    {
        winScreenPanel.SetActive(true);
        Time.timeScale = 0f; // Oyunu durdurur
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu tekrar ba�lat�r
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Ayn� sahneyi yeniden y�kler
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // MainMenu sahnesine g�t�r�r 
    }
}
