using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : SingletonGeneric<ResourceHandler>
{
    [SerializeField]
    private int coins;
    [SerializeField]
    private int gems;
}
