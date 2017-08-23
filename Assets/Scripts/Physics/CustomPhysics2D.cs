using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics2D : MonoBehaviour {
    public const float GRAVITY_CONST = 9.8f;

    public float gravityScale;
    public Vector2 velocity;

    private void Awake()
    {
        
    }

    private void Update()
    {
        UpdatePositionBasedOnVelocity();
    }

    /// <summary>
    /// This strictly moves the transform  based on the velocity. Other checks will be necessary to detect
    /// collisions
    /// </summary>
    private void UpdatePositionBasedOnVelocity()
    {
        Vector3 positionOffset = velocity * Time.deltaTime;
        transform.position = transform.position + positionOffset;
    }
}
