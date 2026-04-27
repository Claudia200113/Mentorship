using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndHorMovement : MonoBehaviour
{
    [SerializeField] private float timeBetweenJumps = 3;
    [SerializeField] private float jumpForce;
    private      Rigidbody2D     rigidBody;
    private AudioSource audioSource;
    
    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        audioSource.Stop();
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenJumps);
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
