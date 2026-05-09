using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates an infinite background by offsetting the image and tilling it
public class BG : MonoBehaviour
{
    private Material mat;
    private float distance;

    [Range(0f, 0.5f)] public float speed = 0.2f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void LateUpdate()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
