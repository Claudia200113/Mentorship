using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace A2
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool DEBUG;

        private      Rigidbody2D     rigidBody;
        [HideInInspector]
        public      Vector2         playerDirection;
        private     SpriteRenderer  spriteRenderer;

        [Header("Movement variables")]
        public      float           playerSpeedForward = 5f;
        public      float           playerSpeedBackwards = 1.5f;
        private     bool            playerGoingBackwards;
        private     float           normalGravity;
        private     float           fallingGravity;
        private     float           scalingGravityFactor = 1f;


        [Header("Jump variables")]
        public      float           jumpForce = 5f;
        public      LayerMask       groundLayer;
        public      float           groundDistanceToJump = 0.3f;
        [HideInInspector]
        public      bool            isGrounded;
        private     bool            isJumping;
        public      Transform       feetPosition;


        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            normalGravity = rigidBody.gravityScale;
            fallingGravity = normalGravity + scalingGravityFactor;
        }
        void Update()
        {
            ListenForInputs();
        }

        private void FixedUpdate()
        {
            ProcessInputs();
        }

        private void ListenForInputs()
        {
            isGrounded = Physics2D.Raycast(feetPosition.position, Vector2.down, groundDistanceToJump, groundLayer);
            float directionX = Input.GetAxis("Horizontal");

            if (directionX < 0)
            {
                playerGoingBackwards = true;
            }
            else
            {
                playerGoingBackwards = false;
            }

            playerDirection = new Vector2(directionX, 0);

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
            }
        }

        private void ProcessInputs()
        {
            Vector2 currentVelocity = rigidBody.velocity;

            if (playerGoingBackwards)
            {
                if (DEBUG)
                {
                    Debug.Log("PLAYER: Going backwards setting speed to: " + playerSpeedBackwards);
                }

                rigidBody.velocity = new Vector2(playerDirection.x * playerSpeedBackwards, currentVelocity.y);
                spriteRenderer.flipX = true;
            }
            else 
            {
                if (DEBUG)
                {
                    Debug.Log("PLAYER: Going forward setting speed to: " + playerSpeedForward);
                }

                rigidBody.velocity = new Vector2(playerDirection.x * playerSpeedForward, currentVelocity.y);
                spriteRenderer.flipX = false;
            }

            if (isJumping)
            {
                if (DEBUG)
                {
                    Debug.Log("PLAYER: Player is jumping");
                }

                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = false;
            }

            if (rigidBody.velocity.y < 0)
            {
                rigidBody.gravityScale = fallingGravity;
            }
            else if (rigidBody.velocity.y >= 0) 
            {
                rigidBody.gravityScale = normalGravity;
            }
            if (DEBUG)
            {
                Debug.DrawRay(transform.position, rigidBody.velocity, Color.red);
            }
        }

        private void OnDrawGizmos()
        {
            if (DEBUG)
            {
                Gizmos.color = new Color(.165f, .824f, .871f, .5f);
                Gizmos.DrawSphere(feetPosition.position, groundDistanceToJump);
            }
        }
    }
}
