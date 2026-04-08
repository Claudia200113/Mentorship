using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
   [Header("Gem")]
   [SerializeField] private PoolLogic.PoolType gemFX;
   [SerializeField] private float lifeTimeGemFX = 2f;
   
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            PickUpGem(collision);
        }
    }

    private void PickUpGem(Collider2D collision)
    {
        GameManager.Instance.playerInventory.AddGem();
        StartCoroutine(GameManager.Instance.spawner.SingleSpawn(
            gemFX,
            collision.transform.position,
            lifeTimeGemFX));
        AudioManager.Instance.PlaySFX(AudioManager.Instance.gem);
    }
}
