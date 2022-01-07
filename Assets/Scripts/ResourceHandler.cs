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
    }

    public void DecreaseGems(int valueToDecrease)
    {
        gems -= valueToDecrease;
    }
    public void IncreaseCoins(int valueToIncrease)
    {
        coins += valueToIncrease;
    }
    public void DecreaseCoins(int valueToDecrease)
    {
        coins -= valueToDecrease;
    }



}
