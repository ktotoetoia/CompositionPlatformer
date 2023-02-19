using UnityEngine;

[RequireComponent(typeof(GroundCheck))]
public class DoubleJump : MonoBehaviour
{
    [SerializeField] private GameObject smoke;

    private GroundCheck groundCheck;
    private Movement movement;

    private bool canDoubleJump;
    private void Start()
    {
        groundCheck = GetComponent<GroundCheck>();
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (groundCheck.IsOnGround) canDoubleJump = true;

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            TryDoubleJump();
        }
    }

    private bool TryDoubleJump()
    {
        if (canDoubleJump && !groundCheck.IsOnGround)
        {
            canDoubleJump = false;
            movement.Jump(true);

            Instantiate(smoke, transform.position, smoke.transform.rotation);
        }
        return canDoubleJump && !groundCheck.IsOnGround;
    }
}