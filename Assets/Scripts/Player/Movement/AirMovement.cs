using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement : PlayerMovement
{
    public float maxAirVelocity;
    private void FixedUpdate()
    {
        Jump();
    }
    void Jump()
    {
        if (grounded && jumpInput == 1)
        {
            // Calculate the initial velocity required to reach the jump height
            float initialVelocity = Mathf.Sqrt(2 * Physics.gravity.magnitude * jumpHeight);

            // Apply the calculated initial velocity to the Rigidbody along the Y axis
            playerRB.velocity = new Vector3(playerRB.velocity.x, initialVelocity, playerRB.velocity.z);
        }
        if (!grounded)
        {
            // Clamp the velocity magnitude to ensure it does not exceed the maximum velocity
            Vector3 clampedVelocity = playerRB.velocity;
            clampedVelocity.x = Mathf.Clamp(clampedVelocity.x, -maxAirVelocity, maxAirVelocity);
            clampedVelocity.z = Mathf.Clamp(clampedVelocity.z, -maxAirVelocity, maxAirVelocity);
            playerRB.velocity = clampedVelocity;
        }
    }
}
