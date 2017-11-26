using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Hitbox : MonoBehaviour {
    #region main variables
    /// <summary>
    /// Reference to the primary character stats script that contains reference to all compoenents and health
    /// </summary>
    public CharacterStats characterStats { get; private set; }
    #endregion main variables

    #region monobehaviour methods

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        Hitbox hitbox = collider.GetComponent<Hitbox>();
        Hurtbox hurtbox = collider.GetComponent<Hurtbox>();

        if (hitbox)
        {

        }
        else if (hurtbox)
        {

        }
    }
    #endregion monobehaviour methods
}
