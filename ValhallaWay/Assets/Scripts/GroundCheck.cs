using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    public JumpController jumpController;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Floor")) {
            jumpController.ArrivedOnGround();
        }
    }
}
