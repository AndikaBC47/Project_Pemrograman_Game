using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float mouseX, mouseY;

    public Transform player, target;

    private AudioSource musicOn;
    void Start()
    {
        musicOn = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HUDManagerScript.isPaused)
        {
            mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            mouseY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            mouseY = Mathf.Clamp(mouseY, -35, 60);
            transform.LookAt(target);
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.rotation = Quaternion.Euler(0, mouseX, 0);
            //parent.Rotate(Vector3.up, mouseX);
        }

    }

    
}
