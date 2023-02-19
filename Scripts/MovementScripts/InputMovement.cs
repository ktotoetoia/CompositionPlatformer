using UnityEngine;

public class InputMovement : Movement
{
    private float horizontal;

    private void Update()
    {
        horizontal = Input.GetAxis(Axis.horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Move(horizontal);
    }
}