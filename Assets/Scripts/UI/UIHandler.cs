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

    public void InitialiseUnlockPopup(int coinCost, int gemCost)
    {
        ToggleChestUnlockPopup(true);
        CoinCostButtonText.text = coinCost.ToString();
        GemCostButtonText.text = gemCost.ToString();
    }

    public void ToggleChestUnlockPopup(bool active)
    {
        chestUnlockPopup.SetActive(active);
    }

}
