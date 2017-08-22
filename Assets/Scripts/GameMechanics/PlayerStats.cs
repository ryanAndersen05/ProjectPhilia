using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a reference to the player's stats. It is used to store any inventory or general stats of the player
/// Specific properties such as speed and jump height will NOT be stored here
/// </summary>
public class PlayerStats : MonoBehaviour {
    public float maxHealth;
    public float currentHealth{ get; private set;}

}
