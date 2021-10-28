using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //Movement 
    public float kecepatan = 4f;
    public float x;
    public float z;

    [SerializeField] private float speed_jump = 3f;
    //Gravitation
    private float gravitasi = -9.8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = -0.4f;
    [SerializeField] private LayerMask groundMask;
    public bool isGrounded;
    Vector3 velocity;

    //Camera 
    private float FOV = 60f;

    public CharacterController controller;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gravity();
        movement();
        lompat();
    }

    private void movement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            kecepatan = 7f;
            Camera.main.fieldOfView = 50f;
        }
        else
        {
            kecepatan = 4f;
            Camera.main.fieldOfView =40f;
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

        
    }

    private void lompat()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(speed_jump * -2f * gravitasi);
        }
        velocity.y += gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
