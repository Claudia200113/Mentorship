
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Spawner : MonoBehaviour
    {
        public bool DEBUG;
      

        void Start()
        {
            goThroughPools();
        }
        
        private void goThroughPools()
        {
            if (GameManager.Instance.spawnerSetups.Count == 0)
            {
                Debug.LogWarning("Spawners weren't set");
            }
            else
            {
                foreach (var pool in GameManager.Instance.spawnerSetups)
                {
                    StartCoroutine(SpawnObjects(pool));
                }
            }
        }
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

