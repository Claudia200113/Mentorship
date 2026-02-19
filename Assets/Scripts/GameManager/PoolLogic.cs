using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PoolLogic : MonoBehaviour
    {
        [HideInInspector] public Dictionary<PoolType, Queue<GameObject>> singlePool;
        public bool DEBUG = false;

        public enum PoolType
        {
            Bat,
            Stalactite,
            Map,
            Health,
            Gem,
            GemPickUpFX,
        }
        
        private void Start()
        {
            SetupPools();
        }

        private void SetupPools()
        {
            singlePool = new Dictionary<PoolType, Queue<GameObject>>();

            if (GameManager.Instance.poolsList.Count != 0 )
            {
                foreach (GameManager.Pool pool in GameManager.Instance.poolsList)
                {
                    Queue<GameObject> poolObjectQueue = new Queue<GameObject>();

                    for (int i = 0; i < pool.poolSize; i++)
                    {
                        GameObject obj = Instantiate(pool.prefab, pool.GOParent);
                        obj.SetActive(false);
                        poolObjectQueue.Enqueue(obj);
                    }
                    singlePool.Add(pool.typeOfPool, poolObjectQueue);
                }
            }
            else
            {
                Debug.LogError("POOL LOGIC: No pools were assigned in game manager.");
            }
        }
        public GameObject GetObject(PoolType poolType, Vector3 position)
        {
            if (DEBUG)
            {
                Debug.Log("POOL LOGIC: Getting object type: " + poolType);
            }

            GameObject objectToSpawn = singlePool[poolType].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            return objectToSpawn;
        }

        public void ReturnToQueue(PoolType poolType, GameObject obj)
        {
            obj.SetActive(false);
            singlePool[poolType].Enqueue(obj);
        }
    }


