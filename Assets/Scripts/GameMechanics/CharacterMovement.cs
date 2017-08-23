using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CustomPhysics2D))]
public class CharacterMovement : MonoBehaviour {
    #region main variables
    public float runSpeed = 7.5f;
    public float walkSpeed = 4;

    private float currentSpeed;
    private CustomPhysics2D rigid;
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
