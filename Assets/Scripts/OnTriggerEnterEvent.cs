using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public UnityEvent onEnter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        onEnter.Invoke();
    }
}
