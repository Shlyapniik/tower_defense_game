using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject towersPanel;

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject towersButton;
    [SerializeField] private GameObject settingsButton;
    

    public void LoadShopPanel()
    {
        shopPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void LoadLevelPanel()
    {
        levelPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void LoadTowersPanel()
    {
        towersPanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void BackToMainMenu()
    {
        levelPanel.SetActive(false);
        shopPanel.SetActive(false);
        towersPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
