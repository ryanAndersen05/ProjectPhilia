﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CustomPhysics2D))]
public class CharacterMovement : MonoBehaviour, IPhysicsEvent {
    #region main variables
    #region const variables
    /// <summary>
    /// The value of the horizontal input on the controller that is needed to activate the walk function
    /// </summary>
    private const float WALK_THRESHOLD = .15F;
    /// <summary>
    /// The minimum value on the controller's horizontal input that is required to activate the run functions
    /// </summary>
    private const float RUN_THRESHOLD = .7f;

    private const bool DIRECTION_RIGHT = true;
    private const bool DIRECTION_LEFT = false;
    #endregion const variables
    [Header("Movement Variables")]
    [Tooltip("The desired speed when the character is running")]
    public float runSpeed = 7.5f;
    [Tooltip("The desired speed when a character is walking. Should typically be slower than the run speed")]
    public float walkSpeed = 4;
    [Tooltip("The acceleration of the character while they are on the ground")]
    public float groundAcceleration = 25f;

    [Header("Air Movement Variables")]
    public float airSpeed;
    public float airAcceleration;

    [Header("Jump Varaibles")]
    [Tooltip("The height at which the character should be able to jump when shooting for a full jump")]
    public float jumpHeight = 5;
    [Tooltip("The time it should take in order to reach the desired jump height")]
    public float timeToMaxHeight = 1;

    [Header("Flip Sprite Variables")]
    [Tooltip("Mark this variable true if the sprite is allowed to change directions based on the input")]
    public bool spriteFlipBasedOnInput = true;
    [Tooltip("Represents the current direction of the sprite. If the sprite is facing right, this will be true. NOTE: If the character is not facing right by default you can change its orientation in the inspector through the Sprite Renderer")]
    public bool isFacingRight = true;
    public bool doubleJumpUsed { get; private set; }


    private float currentSpeed;
    private float jumpSpeed;//The speed we want to apply to the player to achieve the desired height and time
    private CustomPhysics2D rigid;


    /// <summary>
    /// This is the horizontal input that was entered by the player or AI to indicate horizontal movement
    /// </summary>
    private float hInput;
    #endregion main variables

    #region monobehaviour methods
    private void Awake()
    {
        this.rigid = GetComponent<CustomPhysics2D>();
        CalculateJumpProperties();
    }

    private void Update()
    {
        UpdateSpeed();
        UpdateSpriteDirection();
    }

    private void OnValidate()
    {
        SetSpriteDirection(this.isFacingRight);

        if (jumpHeight < 0) jumpHeight = 0;
        if (timeToMaxHeight < 0) timeToMaxHeight = 0;
        if (!rigid) rigid = GetComponent<CustomPhysics2D>();
        if (rigid)
        {
            CalculateJumpProperties();
        }
    }


    #endregion monobehaviour methods

    public void SetHorizontalInput(float hInput)
    {
        this.hInput = hInput;
    }


    private void UpdateSpeed()
    {
        float goalSpeed = 0;

        
        if (!rigid.InAir && Mathf.Abs(this.hInput) > WALK_THRESHOLD)
        {
            goalSpeed = Mathf.Sign(this.hInput) * (Mathf.Abs(this.hInput) > RUN_THRESHOLD ? runSpeed : walkSpeed);
        }
        else if (rigid.InAir)
        {
            goalSpeed = rigid.velocity.x;
            if (Mathf.Abs(this.hInput) > WALK_THRESHOLD)
            {
                goalSpeed = Mathf.Sign(this.hInput) * this.airSpeed;
            }
        }
        rigid.velocity = new Vector2(Mathf.MoveTowards(rigid.velocity.x, goalSpeed, Time.deltaTime * (rigid.InAir ? airAcceleration : groundAcceleration)), rigid.velocity.y);
    }

    /// <summary>
    /// Use this method in the update loop to check if the sprite should change directions based on the
    /// horizontal input
    /// </summary>
    private void UpdateSpriteDirection()
    {
        if (!spriteFlipBasedOnInput || Mathf.Abs(this.hInput) < .1f) return;

        if (this.hInput > 0 && !this.isFacingRight)
        {
            SetSpriteDirection(DIRECTION_RIGHT);
        }
        else if (this.hInput < 0 && this.isFacingRight)
        {
            SetSpriteDirection(DIRECTION_LEFT);
        }
    }


    public void SetSpriteDirection (bool isRight)
    {
        this.isFacingRight = isRight;

        if (isFacingRight)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    public void SetFastFall(bool fastFall)
    {
        rigid.applyFastFallScale = fastFall && rigid.InAir;
    }

    public bool Jump(bool jumpButtonDown = true)
    {
        if (doubleJumpUsed && rigid.InAir) return false; //Our player should not be allowed to jump if they are in the air and already used their double jump

        if (jumpButtonDown && !rigid.InAir)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0) + Vector2.up * jumpSpeed;
            return true;
        }
        else if (jumpButtonDown)
        {
            this.doubleJumpUsed = true;
            rigid.velocity = new Vector2(rigid.velocity.x, 0) + Vector2.up * jumpSpeed;
            return true;
        }
        return false;
    }

    private void CalculateJumpProperties()
    {
        this.jumpSpeed = rigid.SetGravityValueBasedOnJump(jumpHeight, timeToMaxHeight);
    }

    #region phyics evnts
    public void OnPlayerGrounded()
    {
        doubleJumpUsed = false;//We can reset the double anytime the character collides with the ground
    }

    public void OnPlayerInAir()
    {

    }
    #endregion physics events
}
