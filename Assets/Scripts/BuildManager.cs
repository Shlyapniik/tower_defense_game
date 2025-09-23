using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] towers; // все доступные башни

    private int selectedTower = -1; // -1 значит "ничего не выбрано"

    private void Awake()
    {
        main = this;
    }

    public Tower GetSelectedTower()
    {
        if (selectedTower < 0 || selectedTower >= towers.Length)
            return null;

        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }

    public Tower GetTowerByIndex(int index)
    {
        if (index < 0 || index >= towers.Length) return null;
        return towers[index];
    }

    public int GetTowerCount()
    {
        return towers.Length;
    }
}
