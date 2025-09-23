using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject exitButton;

    public void LoadLevelPanel(string sceneName)
    {
        levelPanel.SetActive(true);
        playButton.SetActive(false);
        exitButton.SetActive(false);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void BackToMainMenu()
    {
        levelPanel.SetActive(false);
        playButton.SetActive(true);
        exitButton.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
