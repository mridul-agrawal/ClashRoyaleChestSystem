using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour
{
    public ChestController ChestController;
    public void SetControllerReference(ChestController chestController)
    {
        ChestController = chestController;
    }
}
