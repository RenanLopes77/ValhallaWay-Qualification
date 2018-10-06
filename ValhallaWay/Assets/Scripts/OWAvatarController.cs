using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWAvatarController : MonoBehaviour {

    [Header("Level 0 Overworld")]
    public GameObject avatarN0;
    public OverWorldNode curNode;
    public float avatarN0Speed = 10;
    bool moving = false;
    Vector3 destination;

    public void MoveAvatar(OverWorldNode node) {
        moving = true;
        destination = node.gameObject.transform.position;
    }

    private void Update() {
        if (moving) {
            avatarN0.transform.position = Vector3.MoveTowards(avatarN0.transform.position, destination, avatarN0Speed * Time.deltaTime);
            if(Vector3.Distance(avatarN0.transform.position, destination) <= 0.1f) {
                avatarN0.transform.position = destination;
                moving = false;
            }
        } else {
            if (Input.GetAxisRaw("Horizontal") < 0) { // esquerda
                if (curNode.CanMoveTo(Utils.Direction.LEFT)) {
                    MoveAvatar(curNode.LEFT);
                    curNode = curNode.LEFT;
                }
            } else if (Input.GetAxisRaw("Horizontal") > 0) { // Direita
                if (curNode.CanMoveTo(Utils.Direction.RIGHT)) {
                    MoveAvatar(curNode.RIGHT);
                    curNode = curNode.RIGHT;
                }
            } else if (Input.GetAxisRaw("Vertical") > 0) { // Cima
                if (curNode.CanMoveTo(Utils.Direction.UP)) {
                    MoveAvatar(curNode.UP);
                    curNode = curNode.UP;
                }
            } else if (Input.GetAxisRaw("Vertical") < 0) { // Baixo
                if (curNode.CanMoveTo(Utils.Direction.DOWN)) {
                    MoveAvatar(curNode.DOWN);
                    curNode = curNode.DOWN;
                }
            }
        }
    }

    
}
