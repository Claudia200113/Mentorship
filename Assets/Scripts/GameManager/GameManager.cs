using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton type
public class GameManager : MonoBehaviour
{
    //List for pools--------------------------------------------
    public List<Pool> poolsList;
    
    [System.Serializable]
    public class Pool
    {
        public PoolLogic.PoolType typeOfPool;
        public GameObject prefab;
        public int poolSize;
        public Transform GOParent;
    }
    
    //-----------------------------------------------------------
    
    //List for spawners-----------------------------------------------------------
    public List<SpawnerSetup> spawnerSetups;

    [System.Serializable] 
    public class SpawnerSetup
    {
        public PoolLogic.PoolType poolType;
        public float minTimeSpawn;
        public float maxTimeSpawn;
        public Transform spawnLocation;
    }
    //----------------------------------------------------------------------------
    
    [Header("References")]
    public PoolLogic poolLogic;
    
    public static GameManager Instance
    {
        get;
        private set;
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
}
