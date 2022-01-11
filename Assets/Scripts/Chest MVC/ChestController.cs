using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController 
{
    public ChestModel chestModel;
    public ChestState chestState;
    private int coinCost;
    private int gemCost;

    public ChestController(ChestModel chestModel)
    {
        this.chestModel = chestModel;
        ChangeChestState(ChestState.Locked);
        SetCoinCost();
        SetGemCost();
    }

    public void ChangeChestState(ChestState newState)
    {
        chestState = newState;
    }

    public int GetCoinCost()
    {
        return coinCost;
    }

    public int GetGemsCost()
    {
        return gemCost;
    }

    private void SetCoinCost()
    {
        coinCost = 50;
    }

    private void SetGemCost()
    {
        gemCost = 5;
    }

    public bool UnlockChestWithCoins()
    {
        if(ResourceHandler.Instance.GetCoins() >= coinCost)
        {
            ResourceHandler.Instance.DecreaseCoins(coinCost);
            return true;
        } else
        {
            return false;
        }
    }

    public bool UnlockChestWithGems()
    {
        if (ResourceHandler.Instance.GetGems() >= gemCost)
        {
            ResourceHandler.Instance.DecreaseGems(gemCost);
            return true;
        }
        else
        {
            return false;
        }
    }

    public async void StartTimer()
    {
        float duration = chestModel.UnlockDuration;
        while(duration > 0)
        {
            UIHandler.Instance.UpdateTimerUI(duration);
            await new WaitForSeconds(1f);
            duration -= 1;
        }
        UIHandler.Instance.UnlockChest();
        return;
    }


}
