
using System.Collections;
using UnityEngine;

    //Moves the healing components in scene, in case of colliding with the player goes back to the queue

    [RequireComponent(typeof(CircleCollider2D))]
    public class Healing : MonoBehaviour
    {
        public bool DEBUG;
        public float destroyAfterSeconds = 1f;
        public float horizontalSpeed = 2f;
        public int healthGained = 5;

        private new CircleCollider2D collider;
        private SpriteRenderer spriteRenderer;
        void Start()
        {
            //Periodically returns the object to queue 
            StartCoroutine(ReturnToQueueTime());
            collider = GetComponent<CircleCollider2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        private void Update()
        {
            //Debugs the direction the heart is moving to
            if (DEBUG)
            {
                UnityEngine.Debug.DrawRay(transform.position, new Vector3(-horizontalSpeed, 0, 0) * .5f, Color.red);
            }
        }

        //Calls method that moves the asset
        private void FixedUpdate()
        {
            MoveHealth();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            AddHealth(collision);
            PoolLogic.Instance.ReturnToQueue(PoolLogic.PoolType.Health, gameObject);
        }

        //Returns to the queue after a certain amount of time. Works with script PoolLogic()
        IEnumerator ReturnToQueueTime()
        {
            yield return new WaitForSeconds(destroyAfterSeconds);
            PoolLogic.Instance.ReturnToQueue(PoolLogic.PoolType.Health, gameObject);
        }

        //Translates the asset in the scene
        private void MoveHealth()
        {
            transform.Translate(-horizontalSpeed * Time.deltaTime, 0, 0);
        }

        private void AddHealth(Collider2D collision)
        {

            //Gets the health component
            Health health = collision.gameObject.GetComponent<Health>();
            //If the object has a health script
            if (health != null)
            {
                //Adds health
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


