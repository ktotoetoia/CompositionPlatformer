using UnityEngine;

[RequireComponent(typeof(GroundCheck))]

public class FoxAnimation : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;

    private GroundCheck groundCheck;

    private string isRunning = "IsRunning";
    private string isJumping = "IsJumping";
    private string isFalling = "IsFalling";

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        groundCheck = GetComponent<GroundCheck>();
    }

    private void Update()
    {
        if (Mathf.Abs(rigidbody.velocity.x) > 0.1) Running();
        else Idle();

        if (groundCheck.IsOnGround)
        {
            Grounded();
        }

        else
        {
            if (rigidbody.velocity.y > 0) Jumping();
            else Falling();
        }
    }

    public void Idle()
    {
        animator.SetBool(isRunning,false);
    }

    public void Running()
    {
        animator.SetBool(isRunning, true);
    }

    public void Jumping()
    {
        animator.SetBool(isJumping, true);
    }

    public void Falling()
    {
        animator.SetBool(isJumping, false);
        animator.SetBool(isFalling, true);
    }

    public void Grounded()
    {
        animator.SetBool(isFalling, false);
        animator.SetBool(isJumping, false);
    }
}
