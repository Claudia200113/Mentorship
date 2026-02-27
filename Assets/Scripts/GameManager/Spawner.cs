
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Spawner : MonoBehaviour
    {
        public bool DEBUG;
      

        void Start()
        {
            //Checks each pool to spawn the object according to a random interval of time
            goThroughPools();
        }

        //Checks that spawnersetup is greater than 1, if so, will go through the list and spawn the items. 
        private void goThroughPools()
        {
            //Makes sure there are pools set
            if (GameManager.Instance.spawnerSetups.Count == 0)
            {
                Debug.LogError("Spawners weren't set, needs fixing");
            }
            else
            {
                //Go through each pool existing and spawn the objects
                foreach (var pool in GameManager.Instance.spawnerSetups)
                {
                    StartCoroutine(SpawnObjects(pool));
                }
            }
        }
        // Spawns the object by calling the pool script. First sets the location to the given one in the inspector, sets the spawning
        //time between the variables given in inspector, and finally calls the pool script to get the object from the corresponding pool.
        IEnumerator SpawnObjects(GameManager.SpawnerSetup spawnerSetup)
        {
            while (true)
            {
                if (DEBUG)
                {
                    Debug.Log("SPAWNER: Instancing a new prefab type:" + spawnerSetup.spawnerSo.poolType);
                }

                Vector3 locToSpawn = spawnerSetup.spawnLocation.localPosition;
                yield return new WaitForSeconds(Random.Range(spawnerSetup.spawnerSo.minTimeSpawn, spawnerSetup.spawnerSo.maxTimeSpawn));
                GameManager.Instance.poolLogic.GetObject(spawnerSetup.spawnerSo.poolType, locToSpawn);
            }
        }

        public IEnumerator SingleSpawn(PoolLogic.PoolType poolType, Vector3 locToSpawn, float lifeTime)
        { 
            var pool = GameManager.Instance.poolLogic;
           GameObject prefabSpawned = pool.GetObject(poolType, locToSpawn);
           yield return new WaitForSeconds(lifeTime);
           pool.ReturnToQueue(poolType, prefabSpawned);
        }
    }

