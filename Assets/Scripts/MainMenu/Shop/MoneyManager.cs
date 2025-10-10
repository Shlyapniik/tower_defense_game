using System.Runtime.CompilerServices;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    private int money = 250;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
    }

    private void LoadMoney()
    {
        money = 250;//PlayerPrefs.GetInt("money", 0);
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        SaveMoney();
    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            SaveMoney();
            return true;
        }
        return false;
    }


}
