using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{

	private InputController input;
	private JumpController jump;

    [Header("Speed Variables")]
    public float WalkingSpeed;
    public float ClimbingSpeed;
    public float JumpingSpeed;

#pragma warning disable CS0108 // O membro oculta o membro herdado; palavra-chave new ausente
    private void Awake()
#pragma warning restore CS0108 // O membro oculta o membro herdado; palavra-chave new ausente
    {
		base.Awake();
		jump = GetComponent<JumpController>();
		input = new InputController();

        movement.Speed = WalkingSpeed;
        movement.ClimbSpeed = ClimbingSpeed;
        jump.JumpSpeed = JumpingSpeed;
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
