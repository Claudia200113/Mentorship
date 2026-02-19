using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
   [Header("Gem")]
   [SerializeField] private PoolLogic.PoolType gemFX;
   [SerializeField] private float lifeTimeGemFX = 2f;
   
   
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Gem"))
      {
         GameManager.Instance.playerInventory.AddGem();
         StartCoroutine(GameManager.Instance.spawner.SingleSpawn(
            gemFX, 
            collision.transform.position, 
            lifeTimeGemFX));
      }
   }
}
