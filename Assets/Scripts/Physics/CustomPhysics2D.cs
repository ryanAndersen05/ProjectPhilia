using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics2D : MonoBehaviour {
    public const float GRAVITY_CONST = 9.8f;

    #region main variables
    [Tooltip("This controls the scale of the gravity we are applying. This can be controlled outside of this script")]
    public float gravityScale = 1;

    [Tooltip("The vector that represents the direction that the force of cravity will be applied")]
    public Vector2 gravityDirection = Vector2.down;

    public Vector2 velocity { get; set; }

    /// <summary>
    /// This is the value of the gravity after adjusting for everything but gravity-scale
    /// Please be sure to apply the gravity scale to ensure the correct calculations are acheieved
    /// </summary>
    [HideInInspector]
    public float gravityValue { get; private set; }
    /// <summary>
    /// The maximum velocity that can be achieved when in the gravity direction. We can not exceed this y-value
    /// </summary>
    [HideInInspector]
    public float terminalVelocity { get; private set; }
    #endregion main variables


    #region monobehaviour methods
    private void Update()
    {
        UpdatePositionBasedOnVelocity();
    }

    private void FixedUpdate()
    {
        UpdateVelocityFromGravity();
    }
    #endregion monobehaviour methods

    #region apply physics
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
    #endregion apply phyics


    /// <summary>
    /// Sets the gravity value of the custom physics and also returns the jump speed required
    /// to reach the jumpHeight in seconds timeToMaxHeight
    /// </summary>
    /// <param name="jumpHeight"></param>
    /// <param name="timeToMaxHeight"></param>
    /// <returns></returns>
    public float SetGravityValueBasedOnJump(float jumpHeight, float timeToMaxHeight)
    {
        //print("Step 2");
        if (jumpHeight == 0 || timeToMaxHeight == 0)
        {
            //print("Step 3");
            gravityValue = 0;
            return 0;
        }
        //print("Step 4");
        this.gravityValue = (2 * jumpHeight) / Mathf.Pow(timeToMaxHeight, 2);
        return gravityValue * timeToMaxHeight;
    }
}
