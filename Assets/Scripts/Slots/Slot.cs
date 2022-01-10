using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool isEmpty;
    public ChestController chestController;

    private void Start()
    {
        isEmpty = true;
        ToggleSlotButton(false);
    }

    public void AssignNewChestController(ChestController controller)
    {
        isEmpty = false;
        chestController = controller;
        GetComponent<Image>().sprite = chestController.chestModel.ChestSprite;
        ToggleSlotButton(true);
    }

    public void OnSlotClickLogic()
    {
        if(chestController == null) return;         // Button Should be disabled in this condition.

        if(chestController.chestState == ChestState.Locked)
        {
            Debug.Log("Locked");
            // Show a Popup with Unlocking Options.
        } 
        else if(chestController.chestState == ChestState.Unlocking)
        {
            Debug.Log("Unlocking");
            // Button should be disabled in this condition.
        } 
        else if(chestController.chestState == ChestState.Unlocked)
        {
            Debug.Log("Unlocked");
            // Open the chest and increase resources accordingly.
        }

    }

    public void ToggleSlotButton(bool active)
    {
        GetComponent<Button>().enabled = active;
    }

}
