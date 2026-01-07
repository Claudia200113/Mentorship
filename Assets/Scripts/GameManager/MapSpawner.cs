using A2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    //Spawns the map using the pool manager script  
    public class MapSpawner : MonoBehaviour
    {
        public Transform posSpawn;
        public bool DEBUG;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("SpawnerMap"))
            {
                if (DEBUG)
                {
                    Debug.Log("MAP SPAWNER: Collision detected");
                }

                GameManager.Instance.poolLogic.GetObject(PoolLogic.PoolType.Map, posSpawn.localPosition);
            }
            else
            {
                GameManager.Instance.poolLogic.ReturnToQueue(PoolLogic.PoolType.Map, transform.parent.gameObject);
            }
        }
    }

}
