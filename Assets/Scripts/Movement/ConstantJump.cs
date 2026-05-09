using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adds constant jumps on an enemy, works along with the rigidbody. 
public class ConstantJump : MonoBehaviour
{
    [SerializeField] private float timeBetweenJumps;
    [SerializeField] private float jumpForce;
    private      Rigidbody2D     rigidBody;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Jump());
    }
    private void OnEnable()
    {
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        while (true)
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(timeBetweenJumps);
        }
    }
}
