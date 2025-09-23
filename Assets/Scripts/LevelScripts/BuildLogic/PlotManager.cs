using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class PlotManager : MonoBehaviour
{
    [SerializeField] private Tilemap plotTilemap;
    [SerializeField] private GameObject buildMenuPrefab;
    [SerializeField] private Canvas canvas;

    private GameObject currentMenu;

    // список зан€тых клеток
    private HashSet<Vector3Int> occupiedCells = new HashSet<Vector3Int>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            Vector3Int cellPos = plotTilemap.WorldToCell(mouseWorldPos);

            // если нет тайла под клик
            if (!plotTilemap.HasTile(cellPos))
                return;

            // если клетка уже зан€та
            if (occupiedCells.Contains(cellPos))
            {
                Debug.Log("ћесто зан€то: " + cellPos);
                return;
            }

            if (currentMenu != null) return;

            Vector3 cellCenter = plotTilemap.GetCellCenterWorld(cellPos);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(cellCenter);

            currentMenu = Instantiate(buildMenuPrefab, canvas.transform);
            currentMenu.transform.position = screenPos;

            currentMenu.GetComponent<BuildMenu>().Init(cellPos, this);
        }
    }

    public void BuildTower(Vector3Int cellPos, Tower towerToBuild)
    {
        if (towerToBuild.cost > LevelManager.main.currency)
        {
            Debug.Log("Ќе хватает денег!");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        Vector3 cellCenter = plotTilemap.GetCellCenterWorld(cellPos);
        Instantiate(towerToBuild.prefab, cellCenter, Quaternion.identity);

        // помечаем клетку зан€той
        occupiedCells.Add(cellPos);

        if (currentMenu != null) Destroy(currentMenu);
    }
}
