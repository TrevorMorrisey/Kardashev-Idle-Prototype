using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;
    public int currentPower = 0;
    public int currentMaterials = 0;
    public int currentIncome = 0;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(AddIncome());
    }

    private IEnumerator AddIncome()
    {
        while (true)
        {
            currentMaterials += currentIncome;
            yield return new WaitForSeconds(1);
        }
    }

}