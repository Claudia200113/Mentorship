using System;
using System.Collections;
using UnityEngine;


    public class HorizontalMovement : MonoBehaviour
    {
        public bool DEBUG;
        
        [SerializeField] private float horizontalSpeed = 1f;
        [SerializeField] private float destroyAfterSeconds = 5f;
        [SerializeField] private PoolLogic.PoolType poolType;
        
        private AudioSource audioSource;
        
        private void Awake()
        {
            StartCoroutine(ReturnToQueueTime());
        }

        private void Update()
        {
            if (DEBUG)
            {
                Debug.DrawRay(transform.position, new Vector3(-horizontalSpeed, 0, 0) * .5f, Color.red);
            }
        }
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        { 
            transform.Translate(-horizontalSpeed * Time.deltaTime, 0, 0);
            
        }

        IEnumerator ReturnToQueueTime()
        {
            yield return new WaitForSeconds(destroyAfterSeconds);
            ReturnToQueue();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ReturnToQueue();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("TriggerRequeue") || collision.CompareTag("Player"))
            {
                ReturnToQueue();
            }
        }

        private void ReturnToQueue()
        {
            GameManager.Instance.poolLogic.ReturnToQueue(poolType, gameObject);
        }
    }

