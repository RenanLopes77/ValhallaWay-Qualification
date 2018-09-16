using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour {

	protected Movement movement;
	protected Health health;
	protected Climb climb;
    protected AnimationFlip animationFlip;
    public Animator anim;

    protected void Awake () {
		climb = GetComponent<Climb>();
		health = GetComponent<Health>();
		movement = GetComponent<Movement>();

        animationFlip = gameObject.AddComponent<AnimationFlip>();

		climb.CustomCharacterController = this;
	}

	public void CanClimb(bool canClimb)
	{
		movement.CanClimb = canClimb;
	}

    public void UpdateAnimationDirection() { 
        animationFlip.TestFlip(movement.GetCurrentSpeed());
    }

    public void UpdateAnimatorSpeed(float speed) {
        anim.SetFloat("x-speed", speed);
    }
}
