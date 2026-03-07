using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SO_SpawnerSetup", menuName = "SO/SpawnerSetup")]
public class SO_SpawerSetup : UnityEngine.ScriptableObject
{
    public PoolLogic.PoolType poolType;
    public float minTimeSpawn;
    public float maxTimeSpawn;
}
