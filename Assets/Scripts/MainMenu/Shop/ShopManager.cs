using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [System.Serializable]
    public class ChestUI
    {
        public ChestData data;
        public Image icon;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI costText;
        public Button buyButton;
    }

    [SerializeField] private List<ChestUI> chestsUI;
    [SerializeField] private Transform rewardPopupParent;

    private void Start()
    {
        foreach (var chest in chestsUI)
        {
            chest.icon.sprite = chest.data.icon;
            chest.nameText.text = chest.data.chestName;
            chest.costText.text = chest.data.price.ToString();
            chest.buyButton.onClick.AddListener(() => BuyChest(chest.data));
        }
    }

    private void BuyChest(ChestData data)
    {
        if (!MoneyManager.instance.SpendMoney(data.price))
        {
            return;
        }

        OpenChest(data);
    }

    private void OpenChest(ChestData data)
    {
        int count = Random.Range(data.minShards, data.maxShards+1);
        List<string> rewards = new List<string>();

        for(int i = 0; i < count; i++)
        {
            float roll = Random.value;
            string rarity = "Common";

            if (roll <= data.epicChance) rarity = "Epic";
            else if (roll <= data.rareChance + data.epicChance) rarity = "Rare";

            rewards.Add(rarity);
        }

        ShowRewardsUI(data,rewards);
    }

    private void ShowRewardsUI(ChestData data, List<string> rewards)
    {
        Debug.Log($"Open {data.chestName} chest!");
        foreach (var r in rewards)
        {
            Debug.Log($"You gained shard: {r}");
        }
    }
}
