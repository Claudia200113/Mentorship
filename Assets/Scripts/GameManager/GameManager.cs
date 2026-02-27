using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton type
public class GameManager : MonoBehaviour
{
    //List for pools--------------------------------------------
    [Header("Pools")]
    public List<Pool> poolsList;
    
    [System.Serializable]
    public class Pool
    {
        public SO_PoolSetup poolSo;
        public Transform GOParent;
    }
    
    //-----------------------------------------------------------
    
    //List for spawners-----------------------------------------------------------
    [Header("Spawners")]
    public List<SpawnerSetup> spawnerSetups;
    
    [System.Serializable] 
    public class SpawnerSetup
    {
        public SO_SpawerSetup spawnerSo;
        public Transform spawnLocation;
    }
    
    //----------------------------------------------------------------------------
    
    [Header("References")]
    public Health playerHealth;
    public PoolLogic poolLogic;
    public PlayerInventory playerInventory;
    public Spawner spawner;
    
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
