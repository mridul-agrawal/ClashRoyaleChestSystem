using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotsController : SingletonGeneric<ChestSlotsController>
{
    [SerializeField]
    private GameObject[] Slots;
}
