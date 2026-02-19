using A2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
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

}
