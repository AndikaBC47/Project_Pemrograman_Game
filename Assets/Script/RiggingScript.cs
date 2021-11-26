using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingScript : MonoBehaviour
{
    private float player_speed;

    private float x_val;
    private float z_val;

    private bool stat_grounded;
    private bool stat_jump;
    private bool isCrouched;

    private float HP;

    //Reference
    private Animator anim;
    private GameObject player;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player_speed = player.GetComponent<PlayerMovementScript>().kecepatan;
        x_val = player.GetComponent<PlayerMovementScript>().x;
        z_val = player.GetComponent<PlayerMovementScript>().z;
        HP = player.GetComponent<HPSystem>().Health_Point;
        stat_grounded = player.GetComponent<PlayerMovementScript>().isGrounded;
        stat_jump = Input.GetButtonDown("Jump");
        isCrouched = Input.GetKeyDown(KeyCode.C);

        anim.SetFloat("player_speed", player_speed);
        anim.SetFloat("x", x_val);
        anim.SetFloat("z", z_val);
        anim.SetBool("isGrounded", stat_grounded);
        anim.SetBool("status_jump", stat_jump);
        anim.SetBool("status_crouch", isCrouched);

        anim.SetFloat("HP", HP);


    }
}
