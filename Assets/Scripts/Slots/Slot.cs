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
        if(chestController == null) return;

        if(chestController.chestState == ChestState.Locked)
        {
            // Show a Popup with Unlocking Options.
        } 
        else if(chestController.chestState == ChestState.Unlocking)
        {
            // Button should be disabled in this condition.
        } 
        else if(chestController.chestState == ChestState.Unlocked)
        {
            // Open the chest and increase resources accordingly.
        }

    }

}
