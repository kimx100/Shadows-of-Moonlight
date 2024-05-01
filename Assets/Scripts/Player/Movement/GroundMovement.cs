using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : PlayerMovement
{
    public float maxgroundVelocity;
    void FixedUpdate()
    {
        Walk();        
    }
    private void Walk()
    {
        // Calculate the forward direction of the character
        Vector3 characterForward = transform.forward;

        // Use the forward direction as the movement direction
        Vector3 movementDirection = new Vector3(characterForward.x, 0f, characterForward.z);

        // Normalize the movement direction to ensure consistent speed
        movementDirection.Normalize();

        // Apply the movement force
        playerRB.AddForce(movementDirection * verticalInput * movementSpeed, ForceMode.Force);
        playerRB.AddForce(transform.right * horizontalInput * movementSpeed, ForceMode.Force);

        // aply MaxSpeed
        MaxSpeed();
    }
    private void MaxSpeed()
    {
        // Clamp the velocity magnitude to ensure it does not exceed the maximum velocity
        if (jumpInput != 1 || Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 clampedVelocity = playerRB.velocity;
            clampedVelocity.x = Mathf.Clamp(clampedVelocity.x, -maxgroundVelocity, maxgroundVelocity);
            clampedVelocity.z = Mathf.Clamp(clampedVelocity.z, -maxgroundVelocity, maxgroundVelocity);
            playerRB.velocity = clampedVelocity;
        }
    }
}
