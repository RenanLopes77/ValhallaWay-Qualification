using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	protected Movement movement;
	protected Health health;
	protected Climb climb;

	protected void Awake () {
		climb = GetComponent<Climb>();
		health = GetComponent<Health>();
		movement = GetComponent<Movement>();

		climb.CharacterController = this;
	}

	public void CanClimb(bool canClimb)
	{
		movement.CanClimb = canClimb;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
