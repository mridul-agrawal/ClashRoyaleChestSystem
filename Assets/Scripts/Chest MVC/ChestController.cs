using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController 
{
    public ChestModel chestModel;
    public ChestState chestState;
    public ChestController(ChestModel chestModel)
    {
        this.chestModel = chestModel;
        ChangeChestState(ChestState.Locked);
    }

    public void ChangeChestState(ChestState newState)
    {
        chestState = newState;
    }

    public int GetCoinCost()
    {
        return 50;
    }

    public int GetGemsCost()
    {
        return 5;
    }

}
