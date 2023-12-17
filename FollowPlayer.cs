using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        // Set the camera's position relative to the world, not the player
        transform.position = player.TransformPoint(offset);
    }
}
