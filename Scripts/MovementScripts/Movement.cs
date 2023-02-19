using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundCheck))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 6;
    [SerializeField] private float jumpForce = 10;

    private Rigidbody2D rigidbody;
    private GroundCheck groundCheck;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }

    public void Move(float direction)
    {
        rigidbody.velocity = new Vector2(direction *speed,rigidbody.velocity.y);
    }

    public void Jump(bool doubleJump = false)
    {
        if(groundCheck.IsOnGround||doubleJump)
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,jumpForce);
    }
}
