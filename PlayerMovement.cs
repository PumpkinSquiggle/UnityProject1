using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 20f;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public float walkSpeed = 12f;
    public float runSpeed = 20f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;

    public Vector3 move;
    public Vector3 storedVelo;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // inputs
        

        // actually moves the player
        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded)
        {
            move = transform.right * x + transform.forward * z;
            storedVelo = move;

            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetKey("left shift"))
            {
                speed = runSpeed;
            }
            else
            {
                speed = walkSpeed;
            }


            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        if (!isGrounded) {
            move = storedVelo;
        }
        
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); // gravity
    }
}
