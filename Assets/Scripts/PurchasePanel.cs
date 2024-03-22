using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchasePanel : MonoBehaviour
{
    public Color backgroundActiveColor;
    public Color backgroundInactiveColor;

    public Color textActiveColor;
    public Color textInactiveColor;

    public GameObject buildingTab;
    public GameObject upgradeTab;

    public Image buildingTabButtonBackground;
    public Image upgradeTabButtonBackground;

    public TMP_Text buildingTabButtonText;
    public TMP_Text upgradeTabButtonText;

    private bool buildingTabActive = true;

    private void Start()
    {
        SetUI();
    }

    public void ClickBuildingTab()
    {
        buildingTabActive = true;
        SetUI();
    }

    public void ClickUpgradeTab()
    {
        buildingTabActive = false;
        SetUI();
    }

    private void SetUI()
    {
        buildingTab.SetActive(buildingTabActive);
        buildingTabButtonBackground.color = buildingTabActive ? backgroundActiveColor : backgroundInactiveColor;
        buildingTabButtonText.color = buildingTabActive ? textActiveColor : textInactiveColor;

        upgradeTab.SetActive(!buildingTabActive);
        upgradeTabButtonBackground.color = !buildingTabActive ? backgroundActiveColor : backgroundInactiveColor;
        upgradeTabButtonText.color = !buildingTabActive ? textActiveColor : textInactiveColor;
    }

}