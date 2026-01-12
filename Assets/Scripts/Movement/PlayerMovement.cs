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


        [Header("Jump variables")]
        public      float           jumpForce = 5f;
        public      LayerMask       groundLayer;
        public      float           groundDistanceToJump = 0.3f;
        [HideInInspector]
        public      bool            isGrounded;
        private     bool            isJumping;
        private     bool            isInverted;
        public      Transform       feetPosition;


        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            normalGravity = rigidBody.gravityScale;
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
            Vector2 groundCheck = isInverted ? Vector2.up : Vector2.down;
            isGrounded = Physics2D.Raycast(feetPosition.position, groundCheck, groundDistanceToJump, groundLayer);
            float directionX = Input.GetAxis("Horizontal");
            Debug.DrawRay(feetPosition.position, Vector2.down * groundDistanceToJump, Color.red);
            
            if (directionX < 0)
            {
                playerGoingBackwards = true;
            }
            else
            {
                playerGoingBackwards = false;
            }

            playerDirection = new Vector2(directionX, 0);
                
            if (isGrounded && Input.GetButtonDown("Vertical"))
            {
                isJumping = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isInverted = !isInverted;
                rigidBody.gravityScale = isInverted ? normalGravity * -1: normalGravity;
                //spriteRenderer.flipY = !isInverted;
                gameObject.transform.Rotate(180f, 0f, 0f, Space.World);
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
                //gameObject.transform.Rotate(0f, 180f, 0f, Space.World);
            }
            else 
            {
                if (DEBUG)
                {
                    Debug.Log("PLAYER: Going forward setting speed to: " + playerSpeedForward);
                }

                rigidBody.velocity = new Vector2(playerDirection.x * playerSpeedForward, currentVelocity.y);
                spriteRenderer.flipX = false;
                //gameObject.transform.Rotate(0f, 0f, 0f, Space.World);
            }

            if (isJumping)
            {
                if (DEBUG)
                {
                    Debug.Log("PLAYER: Player is jumping");
                }
                
                Vector2 jumpingVector = isInverted ? Vector2.down : Vector2.up;
                rigidBody.AddForce(jumpingVector * jumpForce, ForceMode2D.Impulse);
                isJumping = false;
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
