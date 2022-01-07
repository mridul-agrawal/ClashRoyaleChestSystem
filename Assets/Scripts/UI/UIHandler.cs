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

    public void UpdateGemsUI(int gems)
    {
        valueOfGems.text = gems.ToString();
    }

    public void UpdateCoinsUI(int coins)
    {
        valueOfCoins.text = coins.ToString();
    }

}
