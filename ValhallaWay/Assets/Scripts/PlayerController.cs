using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CustomCharacterController
{

	private InputController input;
	private JumpController jump;
	private bool hasAxe = false;

    [Header("Speed Variables")]
    public float WalkingSpeed;
    public float ClimbingSpeed;
    public float JumpingSpeed;

    [Header("Health")]
    public float HP;
	
	[Header("Checkpoint")]
    public GameObject LastCheckpoint;
	public Button LastCheckpointBtn;

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
	    
	    SetLastCheckpoint();
    }
	
	void Update ()
	{
		if (health.isDead() == false)
		{
			if (input.IsJumpPressed())
			{
				if (movement.IsClimbing)
				{
					movement.IsClimbing = false;
				}
				else
				{
					JumpAnimation();
					jump.PerformJump();
				}
			} 
			else if (input.IsAttackPressed() && hasAxe)
			{
				AttackAnimation();
			}
		}
    }

	private void FixedUpdate()
	{
		movement.Move(input.GetDirection());
		UpdateAnimationDirection();
		UpdateAnimatorSpeed(movement.GetCurrentSpeed());
	}

	public void SetLastCheckpoint()
	{
		LastCheckpointBtn.onClick.AddListener(delegate
		{
			gameObject.transform.position = LastCheckpoint.transform.position;
			health.Save();
		});
	}
        
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Hazard")) 
        {
            health.DealDamage(other.transform.GetComponent<HealthAssist>().Value);
	        jump.KnockBack(1000);
        } 
        else if (other.transform.CompareTag("Death"))
	    {
		    health.Kill();
	    }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Health")) 
        {
            health.Heal(other.transform.GetComponent<HealthAssist>().Value);
            Destroy(other.gameObject);
        } 
        else if (other.transform.CompareTag("EnemyWeapon"))
        {
	        health.DealDamage(other.transform.GetComponent<HealthAssist>().Value);
	        jump.KnockBack(1000);
        }
        else if (other.transform.CompareTag("Axe"))
        {
	        hasAxe = true;
	        Destroy(other.gameObject);
        }
    }
}
