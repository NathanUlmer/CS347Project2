using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;

    //Public variables
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -0.1f;
    public float jumpHeight = 0.01f;
    public float groundDis = 0.1f;
    public bool isFloating;

    //Private variables
    float turnSmoothVelocity;
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Check for ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDis, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.1f;
        }

        //Jump input
        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Gravitational force
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity);

        //Directional movement inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //Directional movement with a third person camera
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
    }
}
