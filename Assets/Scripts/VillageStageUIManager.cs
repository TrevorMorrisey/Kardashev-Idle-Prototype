using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillageStageUIManager : MonoBehaviour
{
    public VillageStageManager villageStageManager;

    public TMP_Text powerText;
    public TMP_Text materialsText;

    public GameObject farmUI;
    public TMP_Text farmCountText;
    public TMP_Text farmIncomeText;
    public TMP_Text farmCostText;

    public void UpdatePowerText(int power)
    {
        powerText.text = "Power: " + power;
    }

    public void UpdateMaterialsText(int materials)
    {
        materialsText.text = "Materials: " + materials;
    }

    public void EnableFarmUI()
    {
        farmUI.SetActive(true);
    }

    public void UpdateFarmUI()
    {
        farmCountText.text = "Farm Count: " + villageStageManager.farmCount + "/5";
        farmIncomeText.text = "Farm Income: " + villageStageManager.farmCount;
        //farmCostText.text = "Farm Cost: " + (villageStageManager.farmCount + 1) * 10;
    }

}