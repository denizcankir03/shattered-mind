using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false); // Oyuna girince panel kapalý olacak
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Paneli aç
        Time.timeScale = 0f; // Oyunu durdur
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Zamaný normale getir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Ayný sahneyi yeniden yükle
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Ana menü sahnesine geç
    }
}
