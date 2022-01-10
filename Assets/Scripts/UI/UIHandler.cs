using System.Collections;
using System.Collections.Generic;
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


    public void UpdateGemsUI(int gems)
    {
        valueOfGems.text = gems.ToString();
    }

    public void UpdateCoinsUI(int coins)
    {
        valueOfCoins.text = coins.ToString();
    }

    public void ShowSlotsFullPopup(bool setActive)
    {
        slotsFullPopup.SetActive(setActive);
    }

    public void InitialiseUnlockPopup(Slot newSlot)
    {
        selectedSlot = newSlot;
        ToggleChestUnlockPopup(true);
        CoinCostButtonText.text = selectedSlot.chestController.GetCoinCost().ToString() + " Coins";
        GemCostButtonText.text = selectedSlot.chestController.GetGemsCost().ToString() + " Gems";
    }

    public void ToggleChestUnlockPopup(bool active)
    {
        if(!active)
        {
            selectedSlot = null;
        }
        chestUnlockPopup.SetActive(active);
    }

    public void ToggleSlotButton(Button slotButton, bool active)
    {
        slotButton.enabled = active;
    }

    public void OnPressUnlockWithCoins()
    {
        bool UnlockSuccess = selectedSlot.chestController.UnlockChestWithCoins();
        if(UnlockSuccess)
        {
            selectedSlot.GetComponent<Image>().sprite = EmptySlotSprite;
            ToggleSlotButton(selectedSlot.GetComponent<Button>(), false);
            selectedSlot.isEmpty = true;
            ToggleChestUnlockPopup(false);
        }

    }

    public void OnPressUnlockWithGems()
    {
        bool UnlockSuccess = selectedSlot.chestController.UnlockChestWithGems();
        if (UnlockSuccess)
        {
            selectedSlot.GetComponent<Image>().sprite = EmptySlotSprite;
            ToggleSlotButton(selectedSlot.GetComponent<Button>(), false);
            selectedSlot.isEmpty = true;
            ToggleChestUnlockPopup(false);
        }
    }

}
