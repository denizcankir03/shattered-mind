using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene"); // Oyun sahnenin adýný buraya yaz!
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Oyundan çýkýlýyor...");
    }
}
