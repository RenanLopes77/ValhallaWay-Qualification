using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
	private CharacterController characterController;

	public CharacterController CharacterController
	{
		get { return characterController; }
		set { characterController = value; }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		CharacterController.CanClimb(true);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		CharacterController.CanClimb(false);
	}
}
