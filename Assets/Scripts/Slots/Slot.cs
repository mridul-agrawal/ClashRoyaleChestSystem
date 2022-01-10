using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isEmpty;
    public ChestController chestController;

    private void Start()
    {
        isEmpty = true;
    }

    public void OnSlotClickLogic()
    {
        if(chestController == null)
        {
            return;
        }

        Debug.Log("Chest Clicked");

    }

}
