using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool DoubleJumpEnabled;
    
    [HideInInspector]
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
            canDoubleJump = true;
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

    public void KnockBack(float force)
    {
        rb2d.velocity = new Vector2(0, 0);
        rb2d.AddForce(new Vector2(9999, 500));
    }

    public void ArrivedOnGround() 
    {
        onGround = true;
        canJump = true;
        canDoubleJump = false;
    }
}
