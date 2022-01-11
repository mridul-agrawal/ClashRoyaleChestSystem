using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : SingletonGeneric<UIHandler>
{
    [SerializeField]
    private Text valueOfGems;
    [SerializeField]
    private Text valueOfCoins;
    [SerializeField]
    private GameObject chestUnlockPopup;
    [SerializeField]
    private Text CoinCostButtonText;
    [SerializeField]
    private Text GemCostButtonText;
    [SerializeField]
    private GameObject slotsFullPopup;
    private Slot selectedSlot;
    [SerializeField]
    private Sprite EmptySlotSprite;
    [SerializeField]
    private GameObject UnlockNowPopup;
    private CancellationTokenSource tokenSource = null;


    public void UpdateGemsUI(int gems)
    {
        valueOfGems.text = gems.ToString();
    }

    public void UpdateCoinsUI(int coins)
    {
        valueOfCoins.text = coins.ToString();
    }

    public void UpdateTimerUI(float TimeLeft)
    {
        selectedSlot.TimerUIText.text = Mathf.Ceil(TimeLeft).ToString() + " sec";
    }

    public void ToggleSlotButton(Button slotButton, bool active)
    {
        slotButton.enabled = active;
    }

    public void ToggleChestUnlockPopup(bool active)
    {
        if (!active)
        {
            selectedSlot = null;
        }
        chestUnlockPopup.SetActive(active);
    }

    public void ToggleTimerUI(GameObject TimerUI, bool active)
    {
        TimerUI.SetActive(active);
    }

    public void ToggleSlotsFullPopup(bool setActive)
    {
        slotsFullPopup.SetActive(setActive);
    }

    public void ToggleUnlockNowPopup(bool active)
    {
        UnlockNowPopup.SetActive(active);
    }

    public void InitialiseUnlockPopup(Slot newSlot)
    {
        selectedSlot = newSlot;
        ToggleChestUnlockPopup(true);
        CoinCostButtonText.text = selectedSlot.chestController.GetCoinCost().ToString() + " Coins";
        GemCostButtonText.text = selectedSlot.chestController.GetGemsCost().ToString() + " Gems";
    }

    public void OnPressUnlockWithCoins()
    {
        bool UnlockSuccess = selectedSlot.chestController.UnlockChestWithCoins();
        if (UnlockSuccess)
        {
            StartUnlocking();
        }

    }

    public void OnPressUnlockWithGems()
    {
        bool UnlockSuccess = selectedSlot.chestController.UnlockChestWithGems();
        if (UnlockSuccess)
        {
            StartUnlocking();
        }
    }

    public void OnPressedUnlockNow()
    {
        StopTimer();
        UnlockChest();
    }

    private void StartUnlocking()
    {
        selectedSlot.chestController.chestState = ChestState.Unlocking;
        ToggleTimerUI(selectedSlot.TimerUIText.gameObject, true);

        tokenSource = new CancellationTokenSource();
        var token = tokenSource.Token;
        selectedSlot.chestController.StartTimer(token);

        chestUnlockPopup.SetActive(false);
    }

    public void StopTimer()
    {
        tokenSource.Cancel();
    }

    public void UnlockChest()
    {
        selectedSlot.chestController.ChangeChestState(ChestState.Unlocked);
        selectedSlot.TimerUIText.text = "Open Chest!";
        ToggleUnlockNowPopup(false);
    }

    public void OpenChest()
    {
        selectedSlot.GetComponent<Image>().sprite = EmptySlotSprite;
        ToggleSlotButton(selectedSlot.GetComponent<Button>(), false);
        selectedSlot.isEmpty = true;
        ToggleTimerUI(selectedSlot.TimerUIText.gameObject, false);
        ToggleChestUnlockPopup(false);
    }

}
