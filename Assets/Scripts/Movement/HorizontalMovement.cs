using UnityEngine;

//Moves enemies in a horizontal line according to the global speed set on the game manager script.
    public class HorizontalMovement : MonoBehaviour
    {
        private float horizontalSpeed;
        [SerializeField] private PoolLogic.PoolType poolType;
        
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            //gets horizontal speed
            horizontalSpeed = GameManager.Instance.globalSpeed;
            //changes direction if instance is warrior, set this way because of animation sprites
            if (poolType == PoolLogic.PoolType.Warrior)
            {
                transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(-horizontalSpeed * Time.deltaTime, 0, 0);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Ground"))
            {
                if(poolType != PoolLogic.PoolType.Map)ReturnToQueue();
            }
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

