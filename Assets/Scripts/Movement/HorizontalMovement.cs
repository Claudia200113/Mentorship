using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace A2
{
    public class HorizontalMovement : MonoBehaviour
    {
        public bool DEBUG;
        public float horizontalSpeed = 1f;
        public float destroyAfterSeconds = 5f;
        private new Rigidbody2D rigidbody;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        //Debugs the direction the enemy is moving towards
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
        private void Start()
        {
            StartCoroutine(ReturnToQueueTime());
        }

        private void Move()
        { 
            transform.Translate(-horizontalSpeed * Time.deltaTime, 0, 0);
        }

        IEnumerator ReturnToQueueTime()
        {
            yield return new WaitForSeconds(destroyAfterSeconds);
            GameManager.Instance.poolLogic.ReturnToQueue(PoolLogic.PoolType.Enemy, gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameManager.Instance.poolLogic.ReturnToQueue(PoolLogic.PoolType.Enemy, gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.poolLogic.ReturnToQueue(PoolLogic.PoolType.Enemy, gameObject);
        }
    }
}
