using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Gem"))
      {
         GameManager.Instance.playerInventory.AddGem();
         StartCoroutine(GameManager.Instance.spawner.SingleSpawn(
            PoolLogic.PoolType.Gem, 
            collision.transform.position, 
            3f));
      }
   }
}
