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
        if (characterMovement) characterMovement.SetHorizontalInput(Input.GetAxisRaw("Horizontal"));
    }
}
