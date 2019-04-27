using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFlip : MonoBehaviour {

    private bool facingRight = true;

    public void TestFlip(float speed) {
        if (speed < 0 && facingRight) {
            facingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (speed > 0 && !facingRight) {
            facingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
	
}
