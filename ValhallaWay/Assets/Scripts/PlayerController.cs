using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CustomCharacterController
{

	private InputController input;
	private JumpController jump;

    [Header("Speed Variables")]
    public float WalkingSpeed;
    public float ClimbingSpeed;
    public float JumpingSpeed;

    [Header("Health")]
    public float HP;

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
        health.HP = HP;
        health.maxHP = HP;
    }

	void Start () {
		
	}
	
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
        base.UpdateAnimationDirection();
        base.UpdateAnimatorSpeed(movement.GetCurrentSpeed());
    }
        
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Hazard")) {
            health.DealDamage(collision.transform.GetComponent<HealthAssist>().Value);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Health")) {
            health.Heal(other.transform.GetComponent<HealthAssist>().Value);
            Destroy(other.gameObject);
        }
    }
}
