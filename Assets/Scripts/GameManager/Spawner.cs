
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Goes through the pools and sets a timed spawn
    public class Spawner : MonoBehaviour
    {
        public bool DEBUG;
      

        void Start()
        {
            goThroughPools();
        }
        
        private void goThroughPools()
        {
            //Security check to see if at least one spawner is set.
            if (GameManager.Instance.spawnerSetups.Count == 0)
            {
                Debug.LogWarning("Spawners weren't set");
            }
            else
            {
                //For each spawner set on the game manager, spawn the objects
                foreach (var pool in GameManager.Instance.spawnerSetups)
                {
                    StartCoroutine(SpawnObjects(pool));
                }
            }
        }
        IEnumerator SpawnObjects(GameManager.SpawnerSetup spawnerSetup)
        {
            //will continuously spawn objects
            while (true)
            {
                if (DEBUG)
                {
                    Debug.Log("SPAWNER: Instancing a new prefab type:" + spawnerSetup.spawnerSo.poolType);
                }

                //gets the location to spawn according to the spawner setup
                Vector3 locToSpawn = spawnerSetup.spawnLocation.localPosition;
                //selects a random time for instance to be spawned
                yield return new WaitForSeconds(Random.Range(spawnerSetup.spawnerSo.minTimeSpawn, spawnerSetup.spawnerSo.maxTimeSpawn));
                //gets the instance using the pool logic script
                GameManager.Instance.poolLogic.GetObject(spawnerSetup.spawnerSo.poolType, locToSpawn);
            }
        }

        //spawns a single instance
        public IEnumerator SingleSpawn(PoolLogic.PoolType poolType, Vector3 locToSpawn, float lifeTime)
        { 
            var pool = GameManager.Instance.poolLogic;
           GameObject prefabSpawned = pool.GetObject(poolType, locToSpawn);
           yield return new WaitForSeconds(lifeTime);
           //returns instance after lifetime has passed
           pool.ReturnToQueue(poolType, prefabSpawned);
        }
    }

