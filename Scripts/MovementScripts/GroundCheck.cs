using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Collider2D collision;

    [SerializeField] private LayerMask ground = 1<<6;

    private bool isOnGround;
    public bool IsOnGround { get { return isOnGround; } }

    private float groundDistance;

    private void Start()
    {
        collision = GetComponent<Collider2D>();

        groundDistance = collision.bounds.size.y / 2f + collision.offset.y;
    }
    private void FixedUpdate()
    {
        isOnGround = IsGrounded();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collision.bounds.center, collision.bounds.size/1.5f, 0f, Vector2.down, groundDistance,ground);
    }
}