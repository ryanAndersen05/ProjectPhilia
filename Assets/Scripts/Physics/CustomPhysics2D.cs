using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics2D : MonoBehaviour {
    public const float GRAVITY_CONST = 9.8f;

    [Tooltip("This controls the scale of the gravity we are applying")]
    public float gravityScale = 1;

    [Tooltip("The vector that represents the direction that the force of cravity will be applied")]
    public Vector2 gravityDirection = Vector2.down;

    public Vector2 velocity { get; set; }

    /// <summary>
    /// This is the value of the gravity after adjusting for everything but gravity-scale
    /// Please be sure to apply the gravity scale to ensure the correct calculations are acheieved
    /// </summary>
    private float gravityValue = GRAVITY_CONST;

    private float terminalVelocity = 15f;

    private void Awake()
    {
        
    }

    private void Update()
    {
        UpdatePositionBasedOnVelocity();
    }

    private void FixedUpdate()
    {
        UpdateVelocityFromGravity();
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

    private void UpdateVelocityFromGravity()
    {
        float adjustVelocitySpeed = Time.fixedDeltaTime * gravityScale * gravityValue;

        velocity += adjustVelocitySpeed * gravityDirection;

        if (velocity.y < -terminalVelocity)
        {
            velocity = new Vector2(velocity.x, -terminalVelocity);
        }
    }
}
