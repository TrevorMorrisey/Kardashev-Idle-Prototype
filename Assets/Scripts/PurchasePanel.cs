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

    public GameObject buildingPanel;
    public GameObject upgradePanel;

    public Image buildingPanelButtonBackground;
    public Image upgradePanelButtonBackground;

    public TMP_Text buildingPanelButtonText;
    public TMP_Text upgradePanelButtonText;

    private bool buildingPanelActive = true;

    public void ClickBuildingPanel()
    {
        buildingPanelActive = true;
        SetUI();
    }

    public void ClickUpgradePanel()
    {
        buildingPanelActive = false;
        SetUI();
    }

    private void SetUI()
    {
        buildingPanel.SetActive(buildingPanelActive);
        buildingPanelButtonBackground.color = buildingPanelActive ? backgroundActiveColor : backgroundInactiveColor;
        buildingPanelButtonText.color = buildingPanelActive ? textActiveColor : textInactiveColor;

        upgradePanel.SetActive(!buildingPanelActive);
        upgradePanelButtonBackground.color = !buildingPanelActive ? backgroundActiveColor : backgroundInactiveColor;
        upgradePanelButtonText.color = !buildingPanelActive ? textActiveColor : textInactiveColor;
    }

}