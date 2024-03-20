using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingUI : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text incomeText;
    public TMP_Text costText;
    public string buildingName;

    public void SetCount(int count, int capacity)
    {
        if (capacity == -1)
        {
            countText.text = buildingName + "s: " + count;
        }
        else
        {
            countText.text = buildingName + "s: " + count + "/" + capacity;
        }
    }

    public void SetIncome(int income, int power, bool isMaterials)
    {
        if (isMaterials)
        {
            incomeText.text = income + " mat/s";
        }
        else
        {
            incomeText.text = power + " power";
        }
    }

    public void SetCost(int cost)
    {
        costText.text = "Buy (" + cost + ")";
    }

}