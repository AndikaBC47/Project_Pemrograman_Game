using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //Movement 
    public float kecepatan;
    public float sped = 4f;
    public float runsped = 7f;
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
    private GameObject hud;
    //Camera 
    private float FOV = 60f;

    public CharacterController controller;
    private float energy;
    void Start()
    {
        hud = GameObject.Find("HUDManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        gravity();
        movement();
        lompat();
        energy = hud.GetComponent<HUDManagerScript>().energy;
    }

    private void movement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            lari();
            if (energy < 0)
            {
                jalan();
                StartCoroutine(DelayAction());
                jalan();
            }
 
        }
        else
        {
            jalan();
        }


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * kecepatan * Time.deltaTime);
    }

    IEnumerator DelayAction()
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSecondsRealtime(5.0f);

        //Do the action after the delay time has finished.
    }
    private void lari()
    {
        kecepatan = runsped;
        Camera.main.fieldOfView = 50f;
    }

    private void jalan()
    {
        kecepatan = sped;
        Camera.main.fieldOfView = 40f;
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
