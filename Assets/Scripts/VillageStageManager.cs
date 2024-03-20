using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageStageManager : MonoBehaviour
{
    public VillageStageUIManager UIManager;
    public Transform cameraTransform;

    public Transform buildingParent;
    public GameObject farmPrefab;
    public GameObject settlementPrefab;

    public Transform riverParent;
    public GameObject riverTilePrefab;

    public Dictionary<Vector2Int, TileData> tiles = new Dictionary<Vector2Int, TileData>();
    private List<Vector2Int> availableLandSpawnLocations = new List<Vector2Int>();
    private List<Vector2Int> availableRiverSpawnLocations = new List<Vector2Int>();

    [HideInInspector] public int farmCount;

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

        availableLandSpawnLocations.Add(new Vector2Int(1, 1));
        availableLandSpawnLocations.Add(new Vector2Int(1, 2));
        availableLandSpawnLocations.Add(new Vector2Int(1, -1));
        availableLandSpawnLocations.Add(new Vector2Int(1, -2));
        availableLandSpawnLocations.Add(new Vector2Int(2, 0));
        availableLandSpawnLocations.Add(new Vector2Int(-2, 0));

        // Set river tile next to village as available spawning location
        availableRiverSpawnLocations.Add(new Vector2Int(0, 0));
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
        if (GameManager.instace.currentMaterials >= 50) // Should only be checked until it has been unlocked
        {
            UIManager.EnableFarmUI();
        }
    }

    public void PerformLabor()
    {
        GameManager.instace.currentMaterials += 5;
        UIManager.UpdateMaterialsText(GameManager.instace.currentMaterials);

        CheckUnlocks();
    }

    public void BuyFarm()
    {
        if (GameManager.instace.currentMaterials >= 50)
        {
            SpawnFarm();
            GameManager.instace.currentMaterials -= 50;
        }
    }

    private void SpawnFarm()
    {
        Vector2Int spawnLocation = availableLandSpawnLocations[Random.Range(0, availableLandSpawnLocations.Count)];
        availableLandSpawnLocations.Remove(spawnLocation);
        Instantiate(farmPrefab, new Vector3(spawnLocation.x, 0, spawnLocation.y), Quaternion.identity, buildingParent);

        List<Vector2Int> adjacentTiles = new List<Vector2Int>
        {
            new Vector2Int(spawnLocation.x, spawnLocation.y + 1),
            new Vector2Int(spawnLocation.x, spawnLocation.y + 2),
            new Vector2Int(spawnLocation.x, spawnLocation.y - 1),
            new Vector2Int(spawnLocation.x, spawnLocation.y - 2),
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
        cameraTransform.localPosition -= new Vector3(0f, 0f, 0.1f);
    }    

}