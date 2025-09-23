using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    [SerializeField] private GameObject gameWinImage;
    [SerializeField] private GameObject gameLoseImage;
    [SerializeField] private TextMeshProUGUI currencyUI;

    [SerializeField] private Animator firstStarAnim;
    [SerializeField] private Animator secondStarAnim;
    [SerializeField] private Animator thirdStarAnim;

    public int playerHealth = 5;

    public int currency;

    private void Awake()
    {
        Time.timeScale = 1;
        main = this;
    }

    private void Start()
    {
        currencyUI.text = currency.ToString();
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        currencyUI.text = currency.ToString();
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            currencyUI.text = currency.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TakeDamage(int dmg)
    {
        playerHealth -= dmg;

        if (playerHealth <= 0)
        {
            Time.timeScale = 0;
            LoseLevel();
        }
    }

    public void EndLevel()
    {
        gameWinImage.SetActive(true);

        if (playerHealth >= 5)
        {
            firstStarAnim.SetBool("isGet", true);
            secondStarAnim.SetBool("isGet", true);
            thirdStarAnim.SetBool("isGet", true);
        }
        else if (playerHealth >= 3)
        {
            firstStarAnim.SetBool("isGet", true);
            secondStarAnim.SetBool("isGet", true);
        }
        else
        {
            firstStarAnim.SetBool("isGet", true);
        }
    }

    public void LoseLevel()
    {
        gameLoseImage.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RepeatLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
