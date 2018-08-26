using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController {
	public Vector2 GetDirection()
	{
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");	
		return new Vector2(hAxis, vAxis);
	}

	public bool IsJumpPressed()
	{
		return Input.GetButtonDown("Jump");
	}
}
