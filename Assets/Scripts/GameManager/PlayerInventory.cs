using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector]
    public int numberGems; 
    
    public void AddGem()
    {
        numberGems++;
    }
}
