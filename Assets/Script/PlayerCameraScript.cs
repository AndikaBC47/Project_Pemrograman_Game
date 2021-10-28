using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    [SerializeField] private float sensitivity;

    private Transform parent;
    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        parent.Rotate(Vector3.up, mouseX);
    }
}
