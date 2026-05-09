using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SO_SpawnerSetup", menuName = "SO/SpawnerSetup")]

//ScriptableObject to set the spawners.
//Takes the pool type and max and min time to spawn the prefab. Time is selected randomly. 
public class SO_SpawerSetup : UnityEngine.ScriptableObject
{
    public PoolLogic.PoolType poolType;
    public float minTimeSpawn;
    public float maxTimeSpawn;
}
