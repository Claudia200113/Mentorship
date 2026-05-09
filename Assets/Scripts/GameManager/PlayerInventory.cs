using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores inventory. Set this way so code can be expanded if more items are added to gameplay.
public class PlayerInventory : MonoBehaviour
{
    [HideInInspector]
    public int numberGems; 
    
    public void AddGem()
    {
        numberGems++;
    }
}
