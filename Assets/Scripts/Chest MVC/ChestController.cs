using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChestController 
{
    public ChestModel chestModel;
    public ChestState chestState;
    private int coinCost;
    private int gemCost;
    private int coinReward;
    private int gemReward;
    private float TimeLeft;

    public ChestController(ChestModel chestModel)
    {
        this.chestModel = chestModel;
        ChangeChestState(ChestState.Locked);
        TimeLeft = chestModel.UnlockDuration;
        SetCoinCost();
        SetGemCost();
        SetReward();
    }

    public void ChangeChestState(ChestState newState)
    {
        chestState = newState;
    }

    public int GetCoinCost()
    {
        SetCoinCost();
        return coinCost;
    }

    public int GetGemsCost()
    {
        SetGemCost();
        return gemCost;
    }

    private void SetReward()
    {
        coinReward = Random.Range(chestModel.MinCoins, chestModel.MaxCoins + 1);
        gemReward = Random.Range(chestModel.MinGems, chestModel.MaxGems + 1);
    }

    private void SetCoinCost()
    {
        coinCost = chestModel.UnlockCost;
    }

    private void SetGemCost()
    {
        gemCost = (int)Mathf.Ceil(TimeLeft / 2);
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
        SetGemCost();
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

    public async void StartTimer(CancellationToken token)
    {
        while(TimeLeft > 0)
        {
            if(token.IsCancellationRequested)
            {
                return;
            }
            UIHandler.Instance.UpdateTimerUI(TimeLeft);
            await new WaitForSeconds(1f);
            TimeLeft -= 1;
        }
        UIHandler.Instance.UnlockChest();
        return;
    }

    public void CollectRewards()
    {
        ResourceHandler.Instance.IncreaseCoins(coinReward);
        ResourceHandler.instance.IncreaseGems(gemReward);
    }


}
