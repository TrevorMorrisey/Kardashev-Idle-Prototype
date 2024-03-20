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
        //farmCountText.text = "Farm Count: " + villageStageManager.farmCount + "/5";
        //farmIncomeText.text = "Farm Income: " + villageStageManager.farmCount;
        //farmCostText.text = "Farm Cost: " + (villageStageManager.farmCount + 1) * 10;
    }

}