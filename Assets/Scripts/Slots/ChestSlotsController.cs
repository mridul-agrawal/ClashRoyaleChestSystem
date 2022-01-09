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
            Debug.Log("No Slot Available");
        } else
        {
            SpawnChestInSlot(Slots[slot]);
        }
    }

    private void SpawnChestInSlot(Slot slot)
    {
        ChestScriptableObject randomChestSO = chestConfiguration.ChestConfigurationMap[Random.Range(0, 4)].ChestSO;
        slot.isEmpty = false;
        slot.chestController = ChestService.Instance.GetChest(randomChestSO);
        slot.GetComponent<Image>().sprite = slot.chestController.chestModel.ChestSprite;
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
