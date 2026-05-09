using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SO_PoolSetup", menuName = "SO/PoolSetup")]

//ScriptableObject to set the pools.
//Takes the pool type, prefab to instance, and the poolSize. 
public class SO_PoolSetup : ScriptableObject
{
    public PoolLogic.PoolType typeOfPool;
    public GameObject prefab;
    public int poolSize;
}
