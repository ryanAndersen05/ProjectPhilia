using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CustomPhysics2D))]
public class CharacterMovement : MonoBehaviour {
    #region main variables
    private const float RUN_THRESHOLD = .7f;

    [Tooltip("The desired speed when the character is running")]
    public float runSpeed = 7.5f;
    [Tooltip("The desired speed when a character is walking. Should typically be slower than the run speed")]
    public float walkSpeed = 4;

    [Tooltip("The acceleration of the character while they are on the ground")]
    public float groundAcceleration = 25f;
    [Tooltip("The height at which the character should be able to jump when shooting for a full jump")]
    public float jumpHeight = 5;
    [Tooltip("The time it should take in order to reach the desired jump height")]
    public float timeToMaxHeight = 1;

    private float currentSpeed;
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
    }

    private void Update()
    {
        UpdateSpeed();
    }

    private void OnValidate()
    {
        
    }
    #endregion monobehaviour methods

    public void SetHorizontalInput(float hInput)
    {
        this.hInput = hInput;
    }

    private void UpdateSpeed()
    {
        float goalSpeed = 0;
        
        if (Mathf.Abs(this.hInput) > .1f) goalSpeed = Mathf.Sign(this.hInput) * (Mathf.Abs(this.hInput) > RUN_THRESHOLD ? runSpeed : walkSpeed);
        rigid.velocity = new Vector2(Mathf.MoveTowards(rigid.velocity.x, goalSpeed, Time.deltaTime * groundAcceleration), rigid.velocity.y);
    }



}
