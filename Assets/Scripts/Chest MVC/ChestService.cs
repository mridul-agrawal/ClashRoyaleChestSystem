using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : SingletonGeneric<ChestService>
{
    public ChestController GetChest(ChestScriptableObject chestSO)
    {
        ChestModel model = new ChestModel(chestSO);
        ChestController controller = new ChestController(model);
        return controller;
    }
}
