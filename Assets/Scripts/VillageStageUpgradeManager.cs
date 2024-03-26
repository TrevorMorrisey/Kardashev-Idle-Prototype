using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageStageUpgradeManager : MonoBehaviour
{
    public VillageStageManager stageManager;

    public GameObject upgradeUIPrefab;
    public Transform upgradeUIParent;

    //public UpgradeData granaryData;
    //public UpgradeData wheatTaxData;
    //public UpgradeData domesticationData;
    //public UpgradeData irrigationData;

    public UpgradeData farmCapacity1Data;
    public UpgradeData farmCapacity2Data;
    public UpgradeData farmCapacity3Data;
    public UpgradeData farmCapacity4Data;
    public UpgradeData farmIncomeAmount1Data;
    public UpgradeData farmIncomeAmount2Data;
    public UpgradeData farmIncomeAmount3Data;
    public UpgradeData farmIncomeTime1Data;
    public UpgradeData farmIncomeTime2Data;

    private UpgradeUI farmCapacity1UI;
    private UpgradeUI farmCapacity2UI;
    private UpgradeUI farmCapacity3UI;
    private UpgradeUI farmCapacity4UI;
    private UpgradeUI farmIncomeAmount1UI;
    private UpgradeUI farmIncomeAmount2UI;
    private UpgradeUI farmIncomeAmount3UI;
    private UpgradeUI farmIncomeTime1UI;
    private UpgradeUI farmIncomeTime2UI;

    [HideInInspector] public bool farmCapacity1Unlocked;
    [HideInInspector] public bool farmCapacity2Unlocked;
    [HideInInspector] public bool farmCapacity3Unlocked;
    [HideInInspector] public bool farmCapacity4Unlocked;
    [HideInInspector] public bool farmIncomeAmount1Unlocked;
    [HideInInspector] public bool farmIncomeAmount2Unlocked;
    [HideInInspector] public bool farmIncomeAmount3Unlocked;
    [HideInInspector] public bool farmIncomeTime1Unlocked;
    [HideInInspector] public bool farmIncomeTime2Unlocked;

    [HideInInspector] public bool farmCapacity1Purchased;
    [HideInInspector] public bool farmCapacity2Purchased;
    [HideInInspector] public bool farmCapacity3Purchased;
    [HideInInspector] public bool farmCapacity4Purchased;
    [HideInInspector] public bool farmIncomeAmount1Purchased;
    [HideInInspector] public bool farmIncomeAmount2Purchased;
    [HideInInspector] public bool farmIncomeAmount3Purchased;
    [HideInInspector] public bool farmIncomeTime1Purchased;
    [HideInInspector] public bool farmIncomeTime2Purchased;

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
    }

    public void ClickPurchaseUpgrade(string upgradeName)
    {
        //Debug.Log("Clicked on " + upgradeName + " upgrade!");
        // TODO: Probably need to manually update building UI when capacity is increased
        if (upgradeName == farmCapacity1Data.upgradeName && GameManager.instace.currentPower >= farmCapacity1Data.requirement)
        {
            farmCapacity1UI.gameObject.SetActive(false);
            farmCapacity1Purchased = true;
            stageManager.farmData.capacity = 2;
        }
        else if (upgradeName == farmCapacity2Data.upgradeName && GameManager.instace.currentPower >= farmCapacity2Data.requirement)
        {
            farmCapacity2UI.gameObject.SetActive(false);
            farmCapacity2Purchased = true;
            stageManager.farmData.capacity = 5;
        }
        else if (upgradeName == farmCapacity3Data.upgradeName && GameManager.instace.currentPower >= farmCapacity3Data.requirement)
        {
            farmCapacity3UI.gameObject.SetActive(false);
            farmCapacity3Purchased = true;
            stageManager.farmData.capacity = 10;
        }
        else if (upgradeName == farmCapacity4Data.upgradeName && GameManager.instace.currentPower >= farmCapacity4Data.requirement)
        {
            farmCapacity4UI.gameObject.SetActive(false);
            farmCapacity4Purchased = true;
            stageManager.farmData.capacity = 20;
        }

        else if (upgradeName == farmIncomeAmount1Data.upgradeName && GameManager.instace.currentPower >= farmIncomeAmount1Data.requirement)
        {
            farmIncomeAmount1UI.gameObject.SetActive(false);
            farmIncomeAmount1Purchased = true;
            stageManager.farmData.incomeAmount = 2;
        }
        else if (upgradeName == farmIncomeAmount2Data.upgradeName && GameManager.instace.currentPower >= farmIncomeAmount2Data.requirement)
        {
            farmIncomeAmount2UI.gameObject.SetActive(false);
            farmIncomeAmount2Purchased = true;
            stageManager.farmData.incomeAmount = 4;
        }
        else if (upgradeName == farmIncomeAmount3Data.upgradeName && GameManager.instace.currentPower >= farmIncomeAmount3Data.requirement)
        {
            farmIncomeAmount3UI.gameObject.SetActive(false);
            farmIncomeAmount3Purchased = true;
            stageManager.farmData.incomeAmount = 8;
        }

        else if (upgradeName == farmIncomeTime1Data.upgradeName && GameManager.instace.currentPower >= farmIncomeTime1Data.requirement)
        {
            farmIncomeTime1UI.gameObject.SetActive(false);
            farmIncomeTime1Purchased = true;
            stageManager.farmData.incomeTime = 4;
        }
        else if (upgradeName == farmIncomeTime2Data.upgradeName && GameManager.instace.currentPower >= farmIncomeTime2Data.requirement)
        {
            farmIncomeTime2UI.gameObject.SetActive(false);
            farmIncomeTime2Purchased = true;
            stageManager.farmData.incomeTime = 3;
        }
    }

}