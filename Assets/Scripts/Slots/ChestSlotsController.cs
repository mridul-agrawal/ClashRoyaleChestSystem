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
    [SerializeField]
    private GameObject slotsFullPopup;


    public void SpawnRandomChest()
    {
        int slot = GetEmptySlot();
        if(slot == -1)
        {
            ShowSlotsFullPopup(true);
        } else
        {
            SpawnChestInSlot(Slots[slot]);
        }
    }

    public void ShowSlotsFullPopup(bool setActive)
    {
        slotsFullPopup.SetActive(setActive);
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
