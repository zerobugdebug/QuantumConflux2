using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenOptions()
    {
        // Implement options menu functionality
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}