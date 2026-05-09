using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages pool creation, initial instance of objects, gets the prefabs, and returns them to the queue. 
    public class PoolLogic : MonoBehaviour
    {
        [HideInInspector] public Dictionary<PoolType, Queue<GameObject>> singlePool;
        public bool DEBUG = false;

        public enum PoolType
        {
            Bat,
            Gem,
            GemPickUpFX,
            Health,
            Map,
            Stalactite,
            Warrior,
        }
        
        private void Start()
        {
            SetupPools();
        }

        //When the game starts each pool is created, and individual prefabs are instanced and deactivated.
        private void SetupPools()
        {
            //A new dictionary is created for each type defined in the PoolType enum
            singlePool = new Dictionary<PoolType, Queue<GameObject>>();

            //First safety check. At least one pool has to be set.
            if (GameManager.Instance.poolsList.Count != 0 )
            {
                foreach (GameManager.Pool pool in GameManager.Instance.poolsList)
                {
                    Queue<GameObject> poolObjectQueue = new Queue<GameObject>();

                    //Goes through the established pool size
                    for (int i = 0; i < pool.poolSo.poolSize; i++)
                    {
                        //Instantiates the prefab and assigns it the given Game Object
                        GameObject obj = Instantiate(pool.poolSo.prefab, pool.GOParent);
                        obj.SetActive(false);
                        //Adds the obj to the queue
                        poolObjectQueue.Enqueue(obj);
                    }
                    //Adds entry to the dictionary 
                    singlePool.Add(pool.poolSo.typeOfPool, poolObjectQueue);
                }
            }
            else
            {
                Debug.LogError("POOL LOGIC: No pools were assigned in game manager.");
            }
        }
        
        //Retrieves obj from the pool, sets the prefab active, sets location to given one on the function argument
        //and returns the obj that was instanced.
        public GameObject GetObject(PoolType poolType, Vector3 position)
        {
            if (DEBUG)
            {
                Debug.Log("POOL LOGIC: Getting object type: " + poolType);
            }
            GameObject objectToSpawn = singlePool[poolType].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            //returns the dequeued instance
            return objectToSpawn;
        }
        
        //Returns prefab to the queue
        public void ReturnToQueue(PoolType poolType, GameObject obj)
        {
            obj.SetActive(false);
            singlePool[poolType].Enqueue(obj);
        }
    }


