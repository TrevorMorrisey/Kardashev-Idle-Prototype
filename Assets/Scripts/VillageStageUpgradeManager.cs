using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageStageUpgradeManager : MonoBehaviour
{
    public GameObject upgradeUIPrefab;
    public Transform upgradeUIParent;

    public UpgradeData granaryData;
    public UpgradeData wheatTaxData;
    public UpgradeData domesticationData;
    public UpgradeData irrigationData;

    private UpgradeUI granaryUI;
    private UpgradeUI wheatTaxUI;
    private UpgradeUI domesticationUI;
    private UpgradeUI irrigationUI;

    [HideInInspector] public bool granaryUnlocked;
    [HideInInspector] public bool wheatTaxUnlocked;
    [HideInInspector] public bool domesticationUnlocked;
    [HideInInspector] public bool irrigationUnlocked;

    private void Start()
    {
        // For each upgrade, create a new upgrade UI object and populate with data
        granaryUI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        granaryUI.SetData(granaryData);
        granaryUI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(granaryData.upgradeName));
        granaryUI.gameObject.SetActive(false);

        wheatTaxUI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        wheatTaxUI.SetData(wheatTaxData);
        wheatTaxUI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(wheatTaxData.upgradeName));
        wheatTaxUI.gameObject.SetActive(false);

        domesticationUI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        domesticationUI.SetData(domesticationData);
        domesticationUI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(domesticationData.upgradeName));
        domesticationUI.gameObject.SetActive(false);

        irrigationUI = Instantiate(upgradeUIPrefab, upgradeUIParent).GetComponent<UpgradeUI>();
        irrigationUI.SetData(irrigationData);
        irrigationUI.buyButton.onClick.AddListener(() => ClickPurchaseUpgrade(irrigationData.upgradeName));
        irrigationUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckUnlocks();
    }

    public void CheckUnlocks()
    {
        if (GameManager.instace.currentPower >= 0 && !granaryUnlocked)
        {
            granaryUnlocked = true;
            granaryUI.gameObject.SetActive(true);
        }

        if (GameManager.instace.currentPower >= 0 && !wheatTaxUnlocked)
        {
            wheatTaxUnlocked = true;
            wheatTaxUI.gameObject.SetActive(true);
        }

        if (GameManager.instace.currentPower >= 10 && !domesticationUnlocked)
        {
            domesticationUnlocked = true;
            domesticationUI.gameObject.SetActive(true);
        }

        if (GameManager.instace.currentPower >= 25 && !irrigationUnlocked)
        {
            irrigationUnlocked = true;
            irrigationUI.gameObject.SetActive(true);
        }
    }

    public void ClickPurchaseUpgrade(string upgradeName)
    {
        //Debug.Log("Clicked on " + upgradeName + " upgrade!");
        if (upgradeName == granaryData.upgradeName && GameManager.instace.currentPower >= granaryData.requirement)
        {
            granaryUI.gameObject.SetActive(false);

        }
        else if (upgradeName == wheatTaxData.upgradeName && GameManager.instace.currentPower >= wheatTaxData.requirement)
        {
            wheatTaxUI.gameObject.SetActive(false);

        }
        else if (upgradeName == domesticationData.upgradeName && GameManager.instace.currentPower >= domesticationData.requirement)
        {
            domesticationUI.gameObject.SetActive(false);

        }
        else if (upgradeName == irrigationData.upgradeName && GameManager.instace.currentPower >= irrigationData.requirement)
        {
            irrigationUI.gameObject.SetActive(false);

        }
    }

}