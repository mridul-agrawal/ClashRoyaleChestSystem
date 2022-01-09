using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestConfigSO", menuName = "ScriptableObjects/Chests/ChestConfigurations")]
public class ChestConfigs : ScriptableObject
{
    // [Serializable]
    public Dictionary<ChestType, ChestScriptableObject> ChestConfiguration;
}
