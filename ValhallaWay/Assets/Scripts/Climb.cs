using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
	private CustomCharacterController customCharacterController;

	public CustomCharacterController CustomCharacterController
	{
		get { return customCharacterController; }
		set { customCharacterController = value; }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		CustomCharacterController.CanClimb(true);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		CustomCharacterController.CanClimb(false);
	}
}
