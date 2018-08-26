using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
	protected Movement movement;
	protected Health health;
	protected Climb climb;
    protected AnimationFlip animationFlip;

    protected void Awake () {
		climb = GetComponent<Climb>();
		health = GetComponent<Health>();
		movement = GetComponent<Movement>();

        animationFlip = gameObject.AddComponent<AnimationFlip>();
        animationFlip.spriteRenderer = spriteRenderer;

		climb.CustomCharacterController = this;
	}

	public void CanClimb(bool canClimb)
	{
		movement.CanClimb = canClimb;
	}

    public void UpdateAnimationDirection() { 
        animationFlip.TestFlip(movement.GetCurrentSpeed());
    }
}
