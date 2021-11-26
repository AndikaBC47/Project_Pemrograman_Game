using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectScript : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            Destroy(gameObject);
        }
    }
}
