using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    [SerializeField] private float sensitivity;

    private Transform parent, target;

    private AudioSource musicOn;
    void Start()
    {
        musicOn = GetComponent<AudioSource>();
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HUDManagerScript.isPaused)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            //float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            //mouseY = Mathf.Clamp(mouseY, -35, 60);
            //transform.LookAt(parent);
            //target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            //parent.rotation = Quaternion.Euler(0, mouseX, 0);
            parent.Rotate(Vector3.up, mouseX);
        }

    }

    
}
