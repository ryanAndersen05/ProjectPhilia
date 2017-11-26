using UnityEngine;

/// <summary>
/// This is a reference to the player's stats. It is used to store any inventory or general stats of the player
/// Specific properties such as speed and jump height will NOT be stored here
/// </summary>
public class PlayerStats : CharacterStats
{
    public CustomPhysics2D rigid { get; private set; }
    public CharacterMovement characterMovement { get; private set; }


    private void Awake()
    {
        rigid = GetComponent<CustomPhysics2D>();
        characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        
    }
}
