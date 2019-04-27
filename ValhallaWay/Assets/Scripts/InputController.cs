using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController {
	public Vector2 GetDirection()
	{
		return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	public bool IsJumpPressed()
	{
		return Input.GetButtonDown("Jump");
	}

	public bool IsAttackPressed()
	{
		return Input.GetButtonDown("Fire1");
	}
}
