using System;
using System.Collections;
using UnityEngine;


    public class HorizontalMovement : MonoBehaviour
    {
        private float horizontalSpeed;
        //[SerializeField] private float destroyAfterSeconds = 5f;
        [SerializeField] private PoolLogic.PoolType poolType;
        
        private AudioSource audioSource;
        
        private void Awake()
        {
            //StartCoroutine(ReturnToQueueTime());
        }
        
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            horizontalSpeed = GameManager.Instance.globalSpeed;
            
            if (poolType == PoolLogic.PoolType.Warrior)
            {
                transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(-horizontalSpeed * Time.deltaTime, 0, 0);
            }
        }

       /* IEnumerator ReturnToQueueTime()
        {
            yield return new WaitForSeconds(destroyAfterSeconds);
            ReturnToQueue();
        }*/

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(poolType != PoolLogic.PoolType.Map) ReturnToQueue();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (poolType != PoolLogic.PoolType.Map)
            {
                if (poolType == PoolLogic.PoolType.Gem && collision.CompareTag("Player"))
                {
                    ReturnToQueue();
                }else if (collision.CompareTag("TriggerRequeue"))
                {
                    ReturnToQueue();
                }
            }
        }

        private void ReturnToQueue()
        {
            GameManager.Instance.poolLogic.ReturnToQueue(poolType, gameObject);
        }
    }

