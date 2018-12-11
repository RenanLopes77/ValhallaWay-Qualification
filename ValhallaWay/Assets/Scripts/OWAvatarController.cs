using UnityEngine;

public class OWAvatarController : MonoBehaviour {

    [Header("Level 0 Overworld")]
    public GameObject avatarN0;
    public OverWorldNode curNode;
    public float avatarN0Speed = 10;
    bool moving = false;
    Vector3 destination;

    public void SetAvatarDestination(OverWorldNode node) {
        moving = true;
        destination = node.gameObject.transform.position;
    }

    private void Update() {
        if (moving) {
            MoveAvatar();
        } else {
            GetDirectionPressed();
        }
    }

    private void GetDirectionPressed()
    {
        if (Input.GetAxisRaw("Horizontal") < 0) { // LEFT
            if (curNode.CanMoveTo(Utils.Direction.LEFT)) {
                SetAvatarDestination(curNode.LEFT);
                curNode = curNode.LEFT;
            }
        } else if (Input.GetAxisRaw("Horizontal") > 0) { // RIGHT
            if (curNode.CanMoveTo(Utils.Direction.RIGHT)) {
                SetAvatarDestination(curNode.RIGHT);
                curNode = curNode.RIGHT;
            }
        } else if (Input.GetAxisRaw("Vertical") > 0) { // UP
            if (curNode.CanMoveTo(Utils.Direction.UP)) {
                SetAvatarDestination(curNode.UP);
                curNode = curNode.UP;
            }
        } else if (Input.GetAxisRaw("Vertical") < 0) { // DOWN
            if (curNode.CanMoveTo(Utils.Direction.DOWN)) {
                SetAvatarDestination(curNode.DOWN);
                curNode = curNode.DOWN;
            }
        }
    }

    private void MoveAvatar()
    {
        avatarN0.transform.position = Vector3.MoveTowards(avatarN0.transform.position, destination, avatarN0Speed * Time.deltaTime);
        if(Vector3.Distance(avatarN0.transform.position, destination) <= 0.1f) {
            avatarN0.transform.position = destination;
            moving = false;
        }
    }
}
