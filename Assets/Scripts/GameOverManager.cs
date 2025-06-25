using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false); // Oyuna girince panel kapal� olacak
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Paneli a�
        Time.timeScale = 0f; // Oyunu durdur
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Zaman� normale getir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Ayn� sahneyi yeniden y�kle
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Ana men� sahnesine ge�
    }
}
