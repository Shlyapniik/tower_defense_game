using UnityEngine;
using UnityEngine.EventSystems;

public class BuildMenu : MonoBehaviour
{
    private Vector3Int cellPos;
    private PlotManager plotManager;

    public void Init(Vector3Int pos, PlotManager manager)
    {
        cellPos = pos;
        plotManager = manager;
    }

    public void SelectTower(int index)
    {
        BuildManager.main.SetSelectedTower(index);
        Tower chosenTower = BuildManager.main.GetSelectedTower();
        plotManager.BuildTower(cellPos, chosenTower);

        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Проверяем: кликнули ли по UI (например, кнопке меню)
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            // Если кликнули в пустое место — закрываем меню
            Destroy(gameObject);
        }
    }
}
