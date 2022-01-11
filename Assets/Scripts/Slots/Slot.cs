using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool isEmpty;
    public ChestController chestController;
    private Button slotButton;
    public Text TimerUIText;


    private void Start()
    {
        isEmpty = true;
        slotButton = GetComponent<Button>();
        UIHandler.Instance.ToggleSlotButton(slotButton, false);
    }

    public void AssignNewChestController(ChestController controller)
    {
        isEmpty = false;
        chestController = controller;
        GetComponent<Image>().sprite = chestController.chestModel.ChestSprite;
        UIHandler.Instance.ToggleSlotButton(slotButton, true);
    }

    public void OnSlotClickLogic()
    {
        if(chestController == null) return;         // Button Should be disabled in this condition.

        if(chestController.chestState == ChestState.Locked)
        {
            Debug.Log("Locked");
            UIHandler.Instance.InitialiseUnlockPopup(this);
            // UIHandler.Instance.ToggleSlotButton(slotButton, false);
            // Show a Popup with Unlocking Options.
        } 
        else if(chestController.chestState == ChestState.Unlocking)
        {
            Debug.Log("Unlocking");
            UIHandler.Instance.ToggleUnlockNowPopup(true);
            // Button should be disabled in this condition.
        } 
        else if(chestController.chestState == ChestState.Unlocked)
        {
            Debug.Log("Unlocked");
            UIHandler.Instance.OpenChest();
            // Open the chest and increase resources accordingly.
        }

    }


}
