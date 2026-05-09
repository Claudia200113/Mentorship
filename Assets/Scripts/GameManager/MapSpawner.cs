using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns map.
//It was set this way so spawn points can be set inside the editor in specific locations and map tiles seamlessly. 
    public class MapSpawner : MonoBehaviour
    {
        public Transform posSpawn;
        public bool DEBUG;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("SpawnerMap"))
            {
                
                GameManager.Instance.poolLogic.GetObject(PoolLogic.PoolType.Map, posSpawn.transform.position);
            }
           else if (collision.CompareTag("MapRequeue"))
           {
               GameManager.Instance.poolLogic.ReturnToQueue(PoolLogic.PoolType.Map, transform.parent.gameObject);
            }
        }
    }