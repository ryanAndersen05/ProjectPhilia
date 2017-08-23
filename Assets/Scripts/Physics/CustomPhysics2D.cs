using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics2D : MonoBehaviour {
    public const float GRAVITY_CONST = 9.8f;

    [Tooltip("This controls the scale of the gravity we are applying")]
    public float gravityScale = 1;
    public Vector2 velocity { get; set; }

    /// <summary>
    /// This is the value of the gravity when 
    /// </summary>
    private float gravityValue = GRAVITY_CONST;

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
