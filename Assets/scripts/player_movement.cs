using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private CharacterController m_controller;
    public float m_speed = 0.7f;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float airSpeedMultiplier = 2f;

    private CharacterController controller;
    private float verticalVelocity = 0f;
    private bool isGrounded = false;
    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
        controller = GetComponent<CharacterController>();


    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move_dir = (horizontal * transform.right) + (vertical * transform.forward);
        move_dir *= m_speed;
        m_controller.Move(move_dir * m_speed);



        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the player
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * Time.deltaTime);

        // Jump if the player is on the ground
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
        }

        // Apply gravity and check if the player is on the ground
        if (controller.isGrounded)
        {
            isGrounded = true;
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        // Move faster if the player is in the air
        if (!isGrounded)
        {
            moveSpeed *= airSpeedMultiplier;
        }
        else
        {
            moveSpeed = 5f; // Reset move speed to default value
        }
    }
}
