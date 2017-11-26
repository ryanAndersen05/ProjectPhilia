using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Character stats contains the basic components of standard NPCs and 
/// is also the parent class of the Player's stats script.
/// 
/// </summary>
public class CharacterStats : MonoBehaviour {
    #region main variables
    [Tooltip("Use this to set the default max health for this character. Max Health can be changed later")]
    public float maxHealth;

    public float currentHealth { get; protected set; }
    public CharacterMovement characterMovement { get; private set; }
    public CustomPhysics2D rigid { get; private set; }
    public CustomCollider2D collisionDetection { get; private set; }
    #endregion main variables

    #region monobehaviour methods
    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        rigid = GetComponent<CustomPhysics2D>();
        collisionDetection = GetComponent<CustomCollider2D>();

    }
    #endregion monobehaviour methods

    /// <summary>
    /// Use this to lower the health of this unit. Will not cause any special animation and will not collect information of
    /// the hitbox that made contact with it
    /// </summary>
    /// <param name="damageTaken"></param>
    public void TakeDamage(float damageTaken)
    {
        
        this.currentHealth -= damageTaken;
    }

    /// <summary>
    /// Use this to lower the health of this unit. This will take the hitbox that was used into consideration when
    /// calculating the damage that was taken
    /// </summary>
    /// <param name="hitbox"></param>
    /// <param name="damageTaken"></param>
    public void TakeDamageFromHitbox(Hitbox hitbox, float damageTaken)
    {
        
    }
}
