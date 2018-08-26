using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool DoubleJumpEnabled;
    public float JumpSpeed;
    
    private bool canJump;
    private bool onGround;
    private bool canDoubleJump;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void PerformJump()
    {
        if (onGround && canJump)
        {
            Jump();
            canJump = false;
            onGround = false;
        }
        else if (DoubleJumpEnabled && !onGround && canDoubleJump)
        {
            Jump();
            canDoubleJump = false;
        }
    }

    private void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(new Vector2(0, JumpSpeed));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Floor"))
        {
            onGround = true;
            canJump = true;
            canDoubleJump = true;
        }
    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (transform.CompareTag("Vine"))
//        {
//            onGround = true;
//            canJump = true;
//            canDoubleJump = true;
//        }
//    }
}
