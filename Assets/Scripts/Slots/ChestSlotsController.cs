//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlotsController : SingletonGeneric<ChestSlotsController>
{
    [SerializeField]
    private Slot[] Slots;
    [SerializeField]
    private ChestConfigs chestConfiguration;

    public void SpawnRandomChest()
    {
        int slot = GetEmptySlot();
        if(slot == -1)
        {
            UIHandler.Instance.ToggleSlotsFullPopup(true);
        } else
        {
            SpawnChestInSlot(Slots[slot]);
        }
    }

    private void SpawnChestInSlot(Slot slot)
    {
        ChestScriptableObject randomChestSO = chestConfiguration.ChestConfigurationMap[Random.Range(0, 4)].ChestSO;
        ChestController chestController = ChestService.Instance.GetChest(randomChestSO);
        slot.AssignNewChestController(chestController);
    }

    private int GetEmptySlot()
    {
        for (int i = 0; i < 4; i++)
        {
            if(Slots[i].isEmpty)
            {
                return i;
            }
        }
        return -1;
    }
}
