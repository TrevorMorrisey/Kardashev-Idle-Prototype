using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text requirementText;
    public Button buyButton;
    public TMP_Text costText;
    public TMP_Text descriptionText;

    public void SetData(UpgradeData data)
    {
        nameText.text = data.upgradeName;
        requirementText.text = data.requirement.ToString();
        costText.text = "Buy (" + data.cost + "s)";
        descriptionText.text = data.description;
    }

}