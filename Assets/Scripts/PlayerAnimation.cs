using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace A2
{

    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private float moveInput;
        private Rigidbody2D rigid;
        private Animator animator;

        private void Start()
        {
            rigid = GetComponentInParent<Rigidbody2D>();
            if (rigid == null)
            {
                Debug.LogWarning("PLAYER ANIMATION: No rigidbody was found on player asset");
            }

            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogWarning("PLAYER ANIMATION: No animator was found on player asset");
            }
        }
        void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            moveInput = Input.GetAxis("Horizontal");
            animator.SetFloat("xMoveInput", moveInput);
            animator.SetFloat("yMoveInput", moveInput);

            //if input is detected, bool in the animator is set
            if (moveInput > 0.1f)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
