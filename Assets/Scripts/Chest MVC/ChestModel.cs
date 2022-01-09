using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestModel 
{
    public ChestModel(ChestScriptableObject ChestSO)
    {
        ChestName = ChestSO.ChestName;
        ChestSprite = ChestSO.ChestSprite;
        UnlockDuration = ChestSO.UnlockDuration;
        MinCoins = ChestSO.MinCoins;
        MaxCoins = ChestSO.MaxCoins;
        MinGems = ChestSO.MinGems;
        MaxGems = ChestSO.MaxGems;
    }

    public float UnlockDuration { get; }
    public int MinCoins { get; }
    public int MaxCoins { get; }
    public string ChestName { get; }
    public Sprite ChestSprite { get; }
    public int MinGems { get; }
    public int MaxGems { get; }
}
