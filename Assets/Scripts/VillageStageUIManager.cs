using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillageStageUIManager : MonoBehaviour
{
    public VillageStageManager villageStageManager;

    public TMP_Text powerText;
    public TMP_Text materialsText;

    public BuildingUI settlementUI;
    public BuildingUI horseMillUI;
    public BuildingUI waterMillUI;

    public BuildingUI farmUI;
    public BuildingUI workshopUI;

    private void Start()
    {
        UpdateBuildingUI(settlementUI, villageStageManager.settlementData);
        UpdateBuildingUI(horseMillUI, villageStageManager.horseMillData);
        UpdateBuildingUI(waterMillUI, villageStageManager.waterMillData);
        UpdateBuildingUI(farmUI, villageStageManager.farmData);
        UpdateBuildingUI(workshopUI, villageStageManager.workshopData);
    }

    private void Update()
    {
        UpdatePowerText(GameManager.instace.currentPower);
        UpdateMaterialsText(GameManager.instace.currentMaterials);
    }

    public void UpdatePowerText(int power)
    {
        powerText.text = "Power: " + power;
    }

    public void UpdateMaterialsText(int materials)
    {
        materialsText.text = "Materials: " + materials;
    }

    public void EnableBuildingUI(BuildingUI buildingUI)
    {
        buildingUI.gameObject.SetActive(true);
    }

    public void UpdateBuildingUI(BuildingUI buildingUI, BuildingData buildingData)
    {
        buildingUI.SetCount(buildingData.count, buildingData.capacity);
        buildingUI.SetIncome(buildingData.incomeAmount, buildingData.power, buildingData.power == 0);
        buildingUI.SetCost(buildingData.currentCost);
    }

}