using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageStageUpgradeManager : MonoBehaviour
{
    public VillageStageManager stageManager;
    public VillageStageUIManager UIManager;

    public GameObject upgradeUIPrefab;
    public Transform upgradeUIParent;

    public UpgradeData farmCapacity1Data;
    public UpgradeData farmCapacity2Data;
    public UpgradeData farmCapacity3Data;
    public UpgradeData farmCapacity4Data;
    public UpgradeData farmIncomeAmount1Data;
    public UpgradeData farmIncomeAmount2Data;
    public UpgradeData farmIncomeAmount3Data;
    public UpgradeData farmIncomeTime1Data;
    public UpgradeData farmIncomeTime2Data;

    public UpgradeData workshopCapacity1Data;
    public UpgradeData workshopCapacity2Data;
    public UpgradeData workshopIncomeAmount1Data;
    public UpgradeData workshopIncomeAmount2Data;
    public UpgradeData workshopIncomeAmount3Data;
    public UpgradeData workshopIncomeTime1Data;
    public UpgradeData workshopIncomeTime2Data;

    private UpgradeUI farmCapacity1UI;
    private UpgradeUI farmCapacity2UI;
    private UpgradeUI farmCapacity3UI;
    private UpgradeUI farmCapacity4UI;
    private UpgradeUI farmIncomeAmount1UI;
    private UpgradeUI farmIncomeAmount2UI;
    private UpgradeUI farmIncomeAmount3UI;
    private UpgradeUI farmIncomeTime1UI;
    private UpgradeUI farmIncomeTime2UI;

    private UpgradeUI workshopCapacity1UI;
    private UpgradeUI workshopCapacity2UI;
    private UpgradeUI workshopIncomeAmount1UI;
    private UpgradeUI workshopIncomeAmount2UI;
    private UpgradeUI workshopIncomeAmount3UI;
    private UpgradeUI workshopIncomeTime1UI;
    private UpgradeUI workshopIncomeTime2UI;

    [HideInInspector] public bool farmCapacity1Unlocked;
    [HideInInspector] public bool farmCapacity2Unlocked;
    [HideInInspector] public bool farmCapacity3Unlocked;
    [HideInInspector] public bool farmCapacity4Unlocked;
    [HideInInspector] public bool farmIncomeAmount1Unlocked;
    [HideInInspector] public bool farmIncomeAmount2Unlocked;
    [HideInInspector] public bool farmIncomeAmount3Unlocked;
    [HideInInspector] public bool farmIncomeTime1Unlocked;
    [HideInInspector] public bool farmIncomeTime2Unlocked;

    [HideInInspector] public bool workshopCapacity1Unlocked;
    [HideInInspector] public bool workshopCapacity2Unlocked;
    [HideInInspector] public bool workshopIncomeAmount1Unlocked;
    [HideInInspector] public bool workshopIncomeAmount2Unlocked;
    [HideInInspector] public bool workshopIncomeAmount3Unlocked;
    [HideInInspector] public bool workshopIncomeTime1Unlocked;
    [HideInInspector] public bool workshopIncomeTime2Unlocked;

    [HideInInspector] public bool farmCapacity1Purchased;
    [HideInInspector] public bool farmCapacity2Purchased;
    [HideInInspector] public bool farmCapacity3Purchased;
    [HideInInspector] public bool farmCapacity4Purchased;
    [HideInInspector] public bool farmIncomeAmount1Purchased;
    [HideInInspector] public bool farmIncomeAmount2Purchased;
    [HideInInspector] public bool farmIncomeAmount3Purchased;
    [HideInInspector] public bool farmIncomeTime1Purchased;
    [HideInInspector] public bool farmIncomeTime2Purchased;

    [HideInInspector] public bool workshopCapacity1Purchased;
    [HideInInspector] public bool workshopCapacity2Purchased;
    [HideInInspector] public bool workshopIncomeAmount1Purchased;
    [HideInInspector] public bool workshopIncomeAmount2Purchased;
    [HideInInspector] public bool workshopIncomeAmount3Purchased;
    [HideInInspector] public bool workshopIncomeTime1Purchased;
    [HideInInspector] public bool workshopIncomeTime2Purchased;

    private void Start()
    {
        // For each upgrade, create a new upgrade UI object and populate with data
        farmCapacity1UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        farmCapacity1UI.SetData(farmCapacity1Data);
        farmCapacity1UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(farmCapacity1Data.upgradeName));
        farmCapacity1UI.gameObject.SetActive(false);

        farmCapacity2UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        farmCapacity2UI.SetData(farmCapacity2Data);
        farmCapacity2UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(farmCapacity2Data.upgradeName));
        farmCapacity2UI.gameObject.SetActive(false);

        farmCapacity3UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        farmCapacity3UI.SetData(farmCapacity3Data);
        farmCapacity3UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(farmCapacity3Data.upgradeName));
        farmCapacity3UI.gameObject.SetActive(false);

        farmCapacity4UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        farmCapacity4UI.SetData(farmCapacity4Data);
        farmCapacity4UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(farmCapacity4Data.upgradeName));
        farmCapacity4UI.gameObject.SetActive(false);


        farmIncomeAmount1UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        farmIncomeAmount1UI.SetData(farmIncomeAmount1Data);
        farmIncomeAmount1UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(farmIncomeAmount1Data.upgradeName));
        farmIncomeAmount1UI.gameObject.SetActive(false);

        farmIncomeAmount2UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        farmIncomeAmount2UI.SetData(farmIncomeAmount2Data);
        farmIncomeAmount2UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(farmIncomeAmount2Data.upgradeName));
        farmIncomeAmount2UI.gameObject.SetActive(false);

        farmIncomeAmount3UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        farmIncomeAmount3UI.SetData(farmIncomeAmount3Data);
        farmIncomeAmount3UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(farmIncomeAmount3Data.upgradeName));
        farmIncomeAmount3UI.gameObject.SetActive(false);


        farmIncomeTime1UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        farmIncomeTime1UI.SetData(farmIncomeTime1Data);
        farmIncomeTime1UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(farmIncomeTime1Data.upgradeName));
        farmIncomeTime1UI.gameObject.SetActive(false);

        farmIncomeTime2UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        farmIncomeTime2UI.SetData(farmIncomeTime2Data);
        farmIncomeTime2UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(farmIncomeTime2Data.upgradeName));
        farmIncomeTime2UI.gameObject.SetActive(false);




        workshopCapacity1UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        workshopCapacity1UI.SetData(workshopCapacity1Data);
        workshopCapacity1UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(workshopCapacity1Data.upgradeName));
        workshopCapacity1UI.gameObject.SetActive(false);

        workshopCapacity2UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        workshopCapacity2UI.SetData(workshopCapacity2Data);
        workshopCapacity2UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(workshopCapacity2Data.upgradeName));
        workshopCapacity2UI.gameObject.SetActive(false);


        workshopIncomeAmount1UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        workshopIncomeAmount1UI.SetData(workshopIncomeAmount1Data);
        workshopIncomeAmount1UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(workshopIncomeAmount1Data.upgradeName));
        workshopIncomeAmount1UI.gameObject.SetActive(false);

        workshopIncomeAmount2UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        workshopIncomeAmount2UI.SetData(workshopIncomeAmount2Data);
        workshopIncomeAmount2UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(workshopIncomeAmount2Data.upgradeName));
        workshopIncomeAmount2UI.gameObject.SetActive(false);

        workshopIncomeAmount3UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        workshopIncomeAmount3UI.SetData(workshopIncomeAmount3Data);
        workshopIncomeAmount3UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(workshopIncomeAmount3Data.upgradeName));
        workshopIncomeAmount3UI.gameObject.SetActive(false);


        workshopIncomeTime1UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        workshopIncomeTime1UI.SetData(workshopIncomeTime1Data);
        workshopIncomeTime1UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(workshopIncomeTime1Data.upgradeName));
        workshopIncomeTime1UI.gameObject.SetActive(false);

        workshopIncomeTime2UI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        workshopIncomeTime2UI.SetData(workshopIncomeTime2Data);
        workshopIncomeTime2UI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(workshopIncomeTime2Data.upgradeName));
        workshopIncomeTime2UI.gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckUnlocks();
    }

    public void CheckUnlocks()
    {
        if (stageManager.farmData.count >= 1 && !farmCapacity1Unlocked)
        {
            farmCapacity1Unlocked = true;
            farmCapacity1UI.gameObject.SetActive(true);
        }

        if (farmCapacity1Purchased && !farmCapacity2Unlocked)
        {
            farmCapacity2Unlocked = true;
            farmCapacity2UI.gameObject.SetActive(true);
        }

        if (farmCapacity2Purchased && !farmCapacity3Unlocked)
        {
            farmCapacity3Unlocked = true;
            farmCapacity3UI.gameObject.SetActive(true);
        }

        if (farmCapacity3Purchased && !farmCapacity4Unlocked)
        {
            farmCapacity4Unlocked = true;
            farmCapacity4UI.gameObject.SetActive(true);
        }


        if (farmCapacity1Purchased && !farmIncomeAmount1Unlocked)
        {
            farmIncomeAmount1Unlocked = true;
            farmIncomeAmount1UI.gameObject.SetActive(true);
        }

        if (farmIncomeAmount1Purchased && !farmIncomeAmount2Unlocked)
        {
            farmIncomeAmount2Unlocked = true;
            farmIncomeAmount2UI.gameObject.SetActive(true);
        }

        if (farmIncomeAmount2Purchased && !farmIncomeAmount3Unlocked)
        {
            farmIncomeAmount3Unlocked = true;
            farmIncomeAmount3UI.gameObject.SetActive(true);
        }

        if (farmIncomeAmount1Purchased && !farmIncomeTime1Unlocked)
        {
            farmIncomeTime1Unlocked = true;
            farmIncomeTime1UI.gameObject.SetActive(true);
        }

        if (farmIncomeTime1Purchased && !farmIncomeTime2Unlocked)
        {
            farmIncomeTime2Unlocked = true;
            farmIncomeTime2UI.gameObject.SetActive(true);
        }



        if (stageManager.workshopData.count >= 1 && !workshopCapacity1Unlocked)
        {
            workshopCapacity1Unlocked = true;
            workshopCapacity1UI.gameObject.SetActive(true);
        }

        if (workshopCapacity1Purchased && !workshopCapacity2Unlocked)
        {
            workshopCapacity2Unlocked = true;
            workshopCapacity2UI.gameObject.SetActive(true);
        }


        if (stageManager.workshopData.count >= 1 && !workshopIncomeAmount1Unlocked)
        {
            workshopIncomeAmount1Unlocked = true;
            workshopIncomeAmount1UI.gameObject.SetActive(true);
        }

        if (workshopIncomeAmount1Purchased && !workshopIncomeAmount2Unlocked)
        {
            workshopIncomeAmount2Unlocked = true;
            workshopIncomeAmount2UI.gameObject.SetActive(true);
        }

        if (workshopIncomeAmount2Purchased && !workshopIncomeAmount3Unlocked)
        {
            workshopIncomeAmount3Unlocked = true;
            workshopIncomeAmount3UI.gameObject.SetActive(true);
        }


        if (workshopIncomeAmount1Purchased && !workshopIncomeTime1Unlocked)
        {
            workshopIncomeTime1Unlocked = true;
            workshopIncomeTime1UI.gameObject.SetActive(true);
        }

        if (workshopIncomeTime1Purchased && !workshopIncomeTime2Unlocked)
        {
            workshopIncomeTime2Unlocked = true;
            workshopIncomeTime2UI.gameObject.SetActive(true);
        }
    }

    public void ClickPurchaseUpgrade(string upgradeName)
    {
        //Debug.Log("Clicked on " + upgradeName + " upgrade!");
        if (upgradeName == farmCapacity1Data.upgradeName && GameManager.instace.currentPower >= farmCapacity1Data.requirement)
        {
            farmCapacity1UI.gameObject.SetActive(false);
            farmCapacity1Purchased = true;
            stageManager.farmData.capacity = 2;
            UIManager.UpdateBuildingUI(UIManager.farmUI, stageManager.farmData);
        }
        else if (upgradeName == farmCapacity2Data.upgradeName && GameManager.instace.currentPower >= farmCapacity2Data.requirement)
        {
            farmCapacity2UI.gameObject.SetActive(false);
            farmCapacity2Purchased = true;
            stageManager.farmData.capacity = 5;
            UIManager.UpdateBuildingUI(UIManager.farmUI, stageManager.farmData);
        }
        else if (upgradeName == farmCapacity3Data.upgradeName && GameManager.instace.currentPower >= farmCapacity3Data.requirement)
        {
            farmCapacity3UI.gameObject.SetActive(false);
            farmCapacity3Purchased = true;
            stageManager.farmData.capacity = 10;
            UIManager.UpdateBuildingUI(UIManager.farmUI, stageManager.farmData);
        }
        else if (upgradeName == farmCapacity4Data.upgradeName && GameManager.instace.currentPower >= farmCapacity4Data.requirement)
        {
            farmCapacity4UI.gameObject.SetActive(false);
            farmCapacity4Purchased = true;
            stageManager.farmData.capacity = 20;
            UIManager.UpdateBuildingUI(UIManager.farmUI, stageManager.farmData);
        }

        else if (upgradeName == farmIncomeAmount1Data.upgradeName && GameManager.instace.currentPower >= farmIncomeAmount1Data.requirement)
        {
            farmIncomeAmount1UI.gameObject.SetActive(false);
            farmIncomeAmount1Purchased = true;
            stageManager.farmData.incomeAmount = 2;
            UIManager.UpdateBuildingUI(UIManager.farmUI, stageManager.farmData);
        }
        else if (upgradeName == farmIncomeAmount2Data.upgradeName && GameManager.instace.currentPower >= farmIncomeAmount2Data.requirement)
        {
            farmIncomeAmount2UI.gameObject.SetActive(false);
            farmIncomeAmount2Purchased = true;
            stageManager.farmData.incomeAmount = 4;
            UIManager.UpdateBuildingUI(UIManager.farmUI, stageManager.farmData);
        }
        else if (upgradeName == farmIncomeAmount3Data.upgradeName && GameManager.instace.currentPower >= farmIncomeAmount3Data.requirement)
        {
            farmIncomeAmount3UI.gameObject.SetActive(false);
            farmIncomeAmount3Purchased = true;
            stageManager.farmData.incomeAmount = 8;
            UIManager.UpdateBuildingUI(UIManager.farmUI, stageManager.farmData);
        }

        else if (upgradeName == farmIncomeTime1Data.upgradeName && GameManager.instace.currentPower >= farmIncomeTime1Data.requirement)
        {
            farmIncomeTime1UI.gameObject.SetActive(false);
            farmIncomeTime1Purchased = true;
            stageManager.farmData.incomeTime = 4;
            UIManager.UpdateBuildingUI(UIManager.farmUI, stageManager.farmData);
        }
        else if (upgradeName == farmIncomeTime2Data.upgradeName && GameManager.instace.currentPower >= farmIncomeTime2Data.requirement)
        {
            farmIncomeTime2UI.gameObject.SetActive(false);
            farmIncomeTime2Purchased = true;
            stageManager.farmData.incomeTime = 3;
            UIManager.UpdateBuildingUI(UIManager.farmUI, stageManager.farmData);
        }



        else if (upgradeName == workshopCapacity1Data.upgradeName && GameManager.instace.currentPower >= workshopCapacity1Data.requirement)
        {
            workshopCapacity1UI.gameObject.SetActive(false);
            workshopCapacity1Purchased = true;
            stageManager.workshopData.capacity = 10;
            UIManager.UpdateBuildingUI(UIManager.workshopUI, stageManager.workshopData);
        }
        else if (upgradeName == workshopCapacity2Data.upgradeName && GameManager.instace.currentPower >= workshopCapacity2Data.requirement)
        {
            workshopCapacity2UI.gameObject.SetActive(false);
            workshopCapacity2Purchased = true;
            stageManager.workshopData.capacity = 25;
            UIManager.UpdateBuildingUI(UIManager.workshopUI, stageManager.workshopData);
        }

        else if (upgradeName == workshopIncomeAmount1Data.upgradeName && GameManager.instace.currentPower >= workshopIncomeAmount1Data.requirement)
        {
            workshopIncomeAmount1UI.gameObject.SetActive(false);
            workshopIncomeAmount1Purchased = true;
            stageManager.workshopData.incomeAmount = 10;
            UIManager.UpdateBuildingUI(UIManager.workshopUI, stageManager.workshopData);
        }
        else if (upgradeName == workshopIncomeAmount2Data.upgradeName && GameManager.instace.currentPower >= workshopIncomeAmount2Data.requirement)
        {
            workshopIncomeAmount2UI.gameObject.SetActive(false);
            workshopIncomeAmount2Purchased = true;
            stageManager.workshopData.incomeAmount = 25;
            UIManager.UpdateBuildingUI(UIManager.workshopUI, stageManager.workshopData);
        }
        else if (upgradeName == workshopIncomeAmount3Data.upgradeName && GameManager.instace.currentPower >= workshopIncomeAmount3Data.requirement)
        {
            workshopIncomeAmount3UI.gameObject.SetActive(false);
            workshopIncomeAmount3Purchased = true;
            stageManager.workshopData.incomeAmount = 50;
            UIManager.UpdateBuildingUI(UIManager.workshopUI, stageManager.workshopData);
        }

        else if (upgradeName == workshopIncomeTime1Data.upgradeName && GameManager.instace.currentPower >= workshopIncomeTime1Data.requirement)
        {
            workshopIncomeTime1UI.gameObject.SetActive(false);
            workshopIncomeTime1Purchased = true;
            stageManager.workshopData.incomeTime = 15;
            UIManager.UpdateBuildingUI(UIManager.workshopUI, stageManager.workshopData);
        }
        else if (upgradeName == workshopIncomeTime2Data.upgradeName && GameManager.instace.currentPower >= workshopIncomeTime2Data.requirement)
        {
            workshopIncomeTime2UI.gameObject.SetActive(false);
            workshopIncomeTime2Purchased = true;
            stageManager.workshopData.incomeTime = 10;
            UIManager.UpdateBuildingUI(UIManager.workshopUI, stageManager.workshopData);
        }
    }

}