using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float zOffset;
    public float yOffset;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newCameraPosition = transform.position;
            newCameraPosition.x = player.position.x;
            newCameraPosition.y = yOffset;
            newCameraPosition.z = zOffset;
            transform.position = newCameraPosition;
        }
    }
}
