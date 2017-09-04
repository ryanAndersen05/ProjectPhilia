using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public bool acceptInputs = true;
    CharacterMovement characterMovement;

	// Use this for initialization
	private void Start ()
    {
        characterMovement = GetComponent<CharacterMovement>();
	}

    private void Update()
    {
        if (characterMovement)
        {
            characterMovement.SetHorizontalInput(Input.GetAxisRaw("Horizontal"));
        }
    }

    #region structs
    private struct BufferButtonStruct
    {
        [Tooltip("The name of the button input that will be read from the Unity InputSettings")]
        public string buttonName;
        [Tooltip("Identifies if a button is currently down. Similar to isDown in the Input class, but is now buffered so it lasts longer")]
        public bool isDown;
        [Tooltip("The amount of time that a button can be buffrered. Since it is not always ideal to use frames, we will use time")]
        public float bufferTime;

    }
    #endregion structs
}
