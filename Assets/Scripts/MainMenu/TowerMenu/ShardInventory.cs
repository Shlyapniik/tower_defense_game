using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ShardInventory : MonoBehaviour
{
    [System.Serializable]
    public class TowerShardData
    {
        public string towerId;
        public int commonShards;
        public int rareShards;
        public int epicShards;
    }

    public static ShardInventory Instance;

    [SerializeField] private List<TowerShardData> towerShards = new List<TowerShardData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadShards();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddShard(string towerId, string rarity, int amount)
    {
        TowerShardData tower = towerShards.Find(t =>  t.towerId == towerId);
        if (tower == null)
        {
            tower = new TowerShardData() { towerId = towerId };
            towerShards.Add(tower);
        }

        switch (rarity)
        {
            case "Common": tower.commonShards += amount; break;
            case "Rare": tower.rareShards += amount; break;
            case "Epic": tower.epicShards += amount; break;
        }

        SaveShards();
        Debug.Log($"Add {amount} {rarity} shards for {towerId}");
    }

    public int GetShardCount(string towerId, string rarity)
    {
        TowerShardData tower = towerShards.Find(t => t.towerId == towerId);
        if (tower == null) return 0;

        return rarity switch
        {
            "Common" => tower.commonShards,
            "Rare" => tower.rareShards,
            "Epic" => tower.epicShards,
            _ => 0
        };
    }

    private void SaveShards()
    {
        string json = JsonUtility.ToJson(new Wrapper { list = towerShards});
        PlayerPrefs.SetString("TowerShards", json);
        PlayerPrefs.Save();
    }

    private void LoadShards()
    {
        if (!PlayerPrefs.HasKey("TowerShards")) return;
        string json = PlayerPrefs.GetString("TowerShards");
        Wrapper wrapper = JsonUtility.FromJson<Wrapper>(json);
        if (wrapper != null && wrapper.list != null)
        {
            towerShards = wrapper.list;
        }
    }

    [System.Serializable]
    private class Wrapper
    {
        public List<TowerShardData> list;
    }
}
