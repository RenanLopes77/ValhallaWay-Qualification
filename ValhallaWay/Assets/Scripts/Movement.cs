using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    public float Speed;
    [HideInInspector]
    public float ClimbSpeed;
	private bool isClimbing;

	public bool IsClimbing
	{
		get { return isClimbing; }
		set { isClimbing = value; }
	}

	private bool canClimb;

	public bool CanClimb
	{
		get { return canClimb; }
		set
		{
			canClimb = value;
			if (!canClimb)
			{
				isClimbing = false;
			}
		}
	}

	private Rigidbody2D rb2d;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	public void Move(Vector2 direction)
	{
		if (CanClimb && !isClimbing && direction.y != 0)
		{
			isClimbing = true;
			rb2d.gravityScale = 0;
		}

		if (!isClimbing && rb2d.gravityScale == 0)
		{
			rb2d.gravityScale = 1;
		}
		
		if (isClimbing)
		{
			rb2d.velocity = new Vector2(
				direction.x * ClimbSpeed * Time.deltaTime,
				direction.y * ClimbSpeed * Time.deltaTime
			);
		}
		else
		{
			rb2d.velocity = new Vector2(
				direction.x * Speed * Time.deltaTime,
				rb2d.velocity.y
			);	
		}
	}
}
