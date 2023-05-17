using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing = 5.0f;
    Vector3 offset;

    void Start ()
    {
        // Find the player game object tagged as Player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Calculate the initial offset.
        offset = transform.position - player.position;
    }
    
    void FixedUpdate ()
    {
        // Create a position the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = player.position + offset;

        // Smoothly interpolate between the camera's current position and its target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

