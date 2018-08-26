using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFlip : MonoBehaviour {

    private bool facingRight = true;
    public SpriteRenderer spriteRenderer;

    public void TestFlip(float speed) {
        if (speed < 0 && facingRight) {
            facingRight = false;
            spriteRenderer.flipX = !facingRight;
        }

        else if (speed > 0 && !facingRight) {
            facingRight = true;
            spriteRenderer.flipX = !facingRight;
        }
    }
	
}
