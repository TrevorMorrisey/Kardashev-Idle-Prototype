using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageStageManager : MonoBehaviour
{
    public VillageStageUIManager UIManager;
    public Transform cameraTransform;

    public Transform buildingParent;

    // Power building prefabs
    public GameObject settlementPrefab;
    public GameObject horseMillPrefab;
    public GameObject waterMillPrefab;

    // Material building prefabs
    public GameObject farmPrefab;
    public GameObject workshopPrefab;

    public Transform riverParent;
    public GameObject riverTilePrefab;

    public Dictionary<Vector2Int, TileData> tiles = new Dictionary<Vector2Int, TileData>();
    private List<Vector2Int> availableLandSpawnLocations = new List<Vector2Int>();
    private List<Vector2Int> availableRiverSpawnLocations = new List<Vector2Int>();

    public BuildingData farmData;
    public BuildingData workshopData;

    public BuildingData settlementData;
    public BuildingData horseMillData;
    public BuildingData waterMillData;

    private bool farmsUnlocked = false;
    private bool workshopsUnlocked = false;

    private bool settlementUnlocked = false;
    private bool horseMillsUnlocked = false;
    private bool waterMillsUnlocked = false;

    private void Start()
    {
        GenerateRiver();

        // Create TileData for village tile and mark as taken
        tiles.Add(new Vector2Int(1, 0), new TileData(new Vector2Int(1, 0), true, false));

        // Create TileData for initial land spawning locations
        tiles.Add(new Vector2Int(1, 1), new TileData(new Vector2Int(1, 1), true, false));
        tiles.Add(new Vector2Int(1, 2), new TileData(new Vector2Int(1, 2), false, false));
        tiles.Add(new Vector2Int(1, -1), new TileData(new Vector2Int(1, -1), false, false));
        tiles.Add(new Vector2Int(1, -2), new TileData(new Vector2Int(1, -2), false, false));
        tiles.Add(new Vector2Int(2, 0), new TileData(new Vector2Int(2, 0), false, false));
        tiles.Add(new Vector2Int(-2, 0), new TileData(new Vector2Int(-2, 0), false, false));
        //tiles.Add(new Vector2Int(-2, 1), new TileData(new Vector2Int(-2, 1), false, false));
        //tiles.Add(new Vector2Int(-2, -1), new TileData(new Vector2Int(-2, -1), false, false));

        availableLandSpawnLocations.Add(new Vector2Int(1, 1));
        availableLandSpawnLocations.Add(new Vector2Int(1, 2));
        availableLandSpawnLocations.Add(new Vector2Int(1, -1));
        availableLandSpawnLocations.Add(new Vector2Int(1, -2));
        availableLandSpawnLocations.Add(new Vector2Int(2, 0));
        availableLandSpawnLocations.Add(new Vector2Int(-2, 0));
        //availableLandSpawnLocations.Add(new Vector2Int(-2, 1));
        //availableLandSpawnLocations.Add(new Vector2Int(-2, -1));

        // Set river tile next to village as available spawning location
        availableRiverSpawnLocations.Add(new Vector2Int(0, 0));
    }

    private void Update()
    {
        CheckUnlocks();
    }

    private void GenerateRiver()
    {
        int straightSegmentDistance = 3; // Expected to be odd
        int totalLength = 81;
        for (int i = -straightSegmentDistance / 2; i <= straightSegmentDistance / 2; i++)
        {
            Instantiate(riverTilePrefab, new Vector3(0, 0, i), Quaternion.identity, riverParent);
            Instantiate(riverTilePrefab, new Vector3(-1, 0, i), Quaternion.identity, riverParent);

            tiles.Add(new Vector2Int(0, i), new TileData(new Vector2Int(0, i), false, true));
            tiles.Add(new Vector2Int(-1, i), new TileData(new Vector2Int(-1, i), false, true));
        }

        int zOffset = 0;
        for (int i = (straightSegmentDistance / 2) + 1; i <= totalLength / 2; i++)
        {
            Instantiate(riverTilePrefab, new Vector3(zOffset, 0, i), Quaternion.identity, riverParent);
            Instantiate(riverTilePrefab, new Vector3(zOffset - 1, 0, i), Quaternion.identity, riverParent);

            tiles.Add(new Vector2Int(zOffset, i), new TileData(new Vector2Int(zOffset, i), false, true));
            tiles.Add(new Vector2Int(zOffset - 1, i), new TileData(new Vector2Int(zOffset - 1, i), false, true));

            zOffset += Random.Range(-1, 2);
        }

        zOffset = 0;
        for (int i = (-straightSegmentDistance / 2) - 1; i >= -totalLength / 2; i--)
        {
            Instantiate(riverTilePrefab, new Vector3(zOffset, 0, i), Quaternion.identity, riverParent);
            Instantiate(riverTilePrefab, new Vector3(zOffset - 1, 0, i), Quaternion.identity, riverParent);

            tiles.Add(new Vector2Int(zOffset, i), new TileData(new Vector2Int(zOffset, i), false, true));
            tiles.Add(new Vector2Int(zOffset - 1, i), new TileData(new Vector2Int(zOffset - 1, i), false, true));

            zOffset += Random.Range(-1, 2);
        }
    }

    private void CheckUnlocks() // This should probably be in a separate class
    {
        if (!farmsUnlocked && GameManager.instace.currentMaterials >= 50) // Should only be checked until it has been unlocked
        {
            farmsUnlocked = true;
            UIManager.EnableBuildingUI(UIManager.farmUI);
        }

        if (!workshopsUnlocked && GameManager.instace.currentMaterials >= 250)
        {
            workshopsUnlocked = true;
            UIManager.EnableBuildingUI(UIManager.workshopUI);
        }

        if (!settlementUnlocked && farmData.count >= 10)
        {
            settlementUnlocked = true;
            UIManager.EnableBuildingUI(UIManager.settlementUI);
        }

        if (!horseMillsUnlocked && settlementData.count >= 5)
        {
            horseMillsUnlocked = true;
            UIManager.EnableBuildingUI(UIManager.horseMillUI);
        }

        if (!waterMillsUnlocked && horseMillData.count >= 5)
        {
            waterMillsUnlocked = true;
            UIManager.EnableBuildingUI(UIManager.waterMillUI);
        }
    }

    public void PerformLabor()
    {
        GameManager.instace.currentMaterials += 500000;
    }

    public void ClickPurchaseBuilding(string buildingName)
    {
        if (buildingName == "Farm")
        {
            PurchaseBuilding(buildingName, farmData, UIManager.farmUI);
        }
        else if (buildingName == "Workshop")
        {
            PurchaseBuilding(buildingName, workshopData, UIManager.workshopUI);
        }
        else if (buildingName == "Settlement")
        {
            PurchaseBuilding(buildingName, settlementData, UIManager.settlementUI);
        }
        else if (buildingName == "Horse Mill")
        {
            PurchaseBuilding(buildingName, horseMillData, UIManager.horseMillUI);
        }
        else if (buildingName == "Water Mill")
        {
            PurchaseBuilding(buildingName, waterMillData, UIManager.waterMillUI);
        }
    }

    public void PurchaseBuilding(string buildingName, BuildingData buildingData, BuildingUI buildingUI)
    {
        if (GameManager.instace.currentMaterials >= buildingData.currentCost)
        {
            SpawnBuilding(buildingName);
            GameManager.instace.currentMaterials -= buildingData.currentCost;

            // Update farm data
            buildingData.count++;
            buildingData.currentCost += buildingData.costScaling * buildingData.count;

            // Update income and power in GameManager
            GameManager.instace.currentIncome += buildingData.incomeAmount;
            GameManager.instace.currentPower += buildingData.power;

            UIManager.UpdateBuildingUI(buildingUI, buildingData);
        }
    }

    private void SpawnBuilding(string buildingName)
    {
        Vector2Int spawnLocation;
        if (buildingName != "Water Mill")
        {
            spawnLocation = availableLandSpawnLocations[Random.Range(0, availableLandSpawnLocations.Count)];
            availableLandSpawnLocations.Remove(spawnLocation);
        }
        else
        {
            spawnLocation = availableRiverSpawnLocations[Random.Range(0, availableRiverSpawnLocations.Count)];
            availableRiverSpawnLocations.Remove(spawnLocation);
        }
        
        if (buildingName == "Farm")
        {
            Instantiate(farmPrefab, new Vector3(spawnLocation.x, 0, spawnLocation.y), Quaternion.identity, buildingParent);
        }
        else if (buildingName == "Workshop")
        {
            Instantiate(workshopPrefab, new Vector3(spawnLocation.x, 0, spawnLocation.y), Quaternion.identity, buildingParent);
        }
        else if (buildingName == "Settlement")
        {
            Instantiate(settlementPrefab, new Vector3(spawnLocation.x, 0, spawnLocation.y), Quaternion.identity, buildingParent);
        }
        else if (buildingName == "Horse Mill")
        {
            Instantiate(horseMillPrefab, new Vector3(spawnLocation.x, 0, spawnLocation.y), Quaternion.identity, buildingParent);
        }
        else if (buildingName == "Water Mill")
        {
            Transform mill = Instantiate(waterMillPrefab, new Vector3(spawnLocation.x, 0, spawnLocation.y), Quaternion.identity, buildingParent).transform;

            // If tile to the left of water mill is not a river, rotate water mill 180 degrees
            if (!tiles.ContainsKey(new Vector2Int(spawnLocation.x - 1, spawnLocation.y)) || !tiles[new Vector2Int(spawnLocation.x - 1, spawnLocation.y)].isRiver)
            {
                mill.Rotate(new Vector3(0, 180, 0));
            }
        }

        List<Vector2Int> adjacentTiles = new List<Vector2Int>
        {
            new Vector2Int(spawnLocation.x, spawnLocation.y + 1),
            new Vector2Int(spawnLocation.x, spawnLocation.y + 2),
            new Vector2Int(spawnLocation.x, spawnLocation.y - 1),
            //new Vector2Int(spawnLocation.x, spawnLocation.y - 2),
            new Vector2Int(spawnLocation.x - 1, spawnLocation.y),
            new Vector2Int(spawnLocation.x + 1, spawnLocation.y)
        };

        foreach (Vector2Int tile in adjacentTiles)
        {
            if (!tiles.ContainsKey(tile))
            {
                tiles.Add(tile, new TileData(tile, false, false));
                availableLandSpawnLocations.Add(tile);
            }
            else if (tiles.ContainsKey(tile) && tiles[tile].isRiver)
            {
                availableRiverSpawnLocations.Add(tile);
            }
        }

        ZoomOutCamera();
    }

    private void ZoomOutCamera()
    {
        cameraTransform.localPosition -= new Vector3(0f, 0f, 0.2f);
    }    

}