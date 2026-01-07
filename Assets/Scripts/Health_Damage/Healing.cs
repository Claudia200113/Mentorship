
using System.Collections;
using UnityEngine;


    [RequireComponent(typeof(CircleCollider2D))]
    public class Healing : MonoBehaviour
    {
        public bool DEBUG;
        public int healthGained = 5;

        private new CircleCollider2D collider;
        private SpriteRenderer spriteRenderer;
        void Start()
        {
            collider = GetComponent<CircleCollider2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            AddHealth(collision);
            GameManager.Instance.poolLogic.ReturnToQueue(PoolLogic.PoolType.Health, gameObject);
        }
        
        private void AddHealth(Collider2D collision)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.GainHealth(healthGained);
                if (DEBUG)
                {
                    UnityEngine.Debug.Log("HEALTH ON COLLISION: Collided, will add health to:" + collision.gameObject.name);
                }
            }
            else
            {
                if (DEBUG)
                {
                    UnityEngine.Debug.Log("HEALTH ON COLLISION: Collided but:" + collision.gameObject.name + " has no health script");
                }
            }
        }
    }


