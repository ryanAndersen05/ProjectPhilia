using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CustomPhysics2D))]
public class CharacterMovement : MonoBehaviour {
    #region main variables
    [Tooltip("The desired speed when the character is running")]
    public float runSpeed = 7.5f;
    [Tooltip({"The desired speed when a character is walking. Should typically be slower than the run speed")]
    public float walkSpeed = 4;

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
        
    }

    private void Update()
    {
        
    }

    private void OnValidate()
    {
        
    }
    #endregion monobehaviour methods

    private void UpdateSpeed()
    {

    }

}
