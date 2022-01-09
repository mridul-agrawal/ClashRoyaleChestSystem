using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : SingletonGeneric<ResourceHandler>
{
    [SerializeField]
    private int coins;
    [SerializeField]
    private int gems;

    public int GetCoins()
    {
        return coins;
    }
    public int GetGems()
    {
        return gems;
    }
    public void IncreaseGems(int valueToIncrease)
    {
        gems += valueToIncrease;
        UIHandler.Instance.UpdateGemsUI(gems);
    }
    public void DecreaseGems(int valueToDecrease)
    {
        gems -= valueToDecrease;
        UIHandler.Instance.UpdateGemsUI(gems);
    }
    public void IncreaseCoins(int valueToIncrease)
    {
        coins += valueToIncrease;
        UIHandler.Instance.UpdateCoinsUI(coins);
    }
    public void DecreaseCoins(int valueToDecrease)
    {
        coins -= valueToDecrease;
        UIHandler.Instance.UpdateCoinsUI(coins);
    }



}
