using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public GameObject winScreenPanel;

    private void Start()
    {
        winScreenPanel.SetActive(false); // Baþlangýçta görünmez
    }

    public void ShowWinScreen()
    {
        winScreenPanel.SetActive(true);
        Time.timeScale = 0f; // Oyunu durdurur
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu tekrar baþlatýr
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Ayný sahneyi yeniden yükler
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // MainMenu sahnesine götürür 
    }
}
