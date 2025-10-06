using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Chest Data", fileName = "NewChestData")]
public class ChestData : ScriptableObject
{
    public string chestName;
    public Sprite icon;          // пиксельный спрайт сундука
    public int price;            // цена в монетах
    public int minShards;        // минимальное количество осколков
    public int maxShards;        // максимальное количество осколков
    [Range(0f, 1f)] public float rareChance; // шанс редких осколков
    [Range(0f, 1f)] public float epicChance; // шанс эпических
}
