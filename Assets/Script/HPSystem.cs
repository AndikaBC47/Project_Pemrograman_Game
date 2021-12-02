using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public float Health_Point;
    public string info;
    void Start()
    {
        Health_Point = 100F;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health_Point > 0)
        {
            Debug.Log("Still Alive");
        }
        else
        {
            Debug.Log("Wasted");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InterObjectDamage")
        {
            Health_Point -= 20f;
            Debug.Log("HP : " + Health_Point);
            info = "How dumb you walking to fire alive?!";
        }
        else if(other.tag == "InterObjectHeal")
        {
            Health_Point += 10f;
            Debug.Log("HP restored = 10");
        }
        else if (other.tag == "Enemy")
        {
            Health_Point -= 30f;
            Debug.Log("Player got hit by enemy = 30f");
            info = "You have been killed by dark enemy";
        }
    }
}
