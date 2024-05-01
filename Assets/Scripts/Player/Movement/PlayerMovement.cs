using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    public float movementSpeed;
    public float jumpHeight;
    public float jumpInput;

    public bool grounded;

    public float verticalInput;
    public float horizontalInput;

    public float groundCheckDistance;
    public Vector3 groundCheckRayOffset;
    public LayerMask groundLayer;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        InputReciever();
        GroundCheck();
    }
    private void InputReciever()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        jumpInput = Input.GetAxisRaw("Jump");
    }
    private void GroundCheck()
    {
        // raycast to check if grounded
        RaycastHit hit;
        if (playerRB.velocity.y < 0.01f && playerRB.velocity.y > -0.01f || Physics.Raycast(transform.position + groundCheckRayOffset, Vector3.down, out hit, groundCheckDistance, groundLayer))
            grounded = true;
        else
            grounded = false;

        // change drag depending on grounded
        if (grounded)
            playerRB.drag = 2;
        else
            playerRB.drag = 0;
    }

    private void OnDrawGizmos()
    {
        //ground raycast
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + groundCheckRayOffset, transform.position + groundCheckRayOffset + Vector3.down * groundCheckDistance);
    }
}
