using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //Movement 
    private float kecepatan = 7f;
    private float x;
    private float z;
    //Gravitation
    private float gravitasi = -9.8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = -0.4f;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded;
    Vector3 velocity;

    public CharacterController controller;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        gravity();
    }

    private void movement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            kecepatan = 16f;
        }
        else
        {
            kecepatan = 7f;
        }


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * kecepatan * Time.deltaTime);
    }

    private void gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
