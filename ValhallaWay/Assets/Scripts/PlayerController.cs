using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{

	private InputController input;
	private JumpController jump;

	private void Awake()
	{
		base.Awake();
		jump = GetComponent<JumpController>();
		input = new InputController();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (input.IsJumpPressed())
		{
			if (movement.IsClimbing)
			{
				movement.IsClimbing = false;
			}
			else
			{
				jump.PerformJump();
			}
		}
		movement.Move(input.GetDirection());
	}
}
