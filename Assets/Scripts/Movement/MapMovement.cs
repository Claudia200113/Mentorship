using A2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace A2
{
    public class MapMovement : MonoBehaviour
    {
        public bool DEBUG;
        private float globalSpeed;

        void FixedUpdate()
        {
            MoveMap();
        }

        private void MoveMap()
        {
            globalSpeed = GameManager.Instance.globalSpeed;
            transform.Translate(-globalSpeed * Time.deltaTime, 0, 0);
        }
    }
}

