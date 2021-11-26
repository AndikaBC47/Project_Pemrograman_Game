using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public float Health_Point;
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
            Time.timeScale = 0.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InterObjectDamage")
        {
            Health_Point -= 20f;
            Debug.Log("HP : " + Health_Point);
        }
        else if(other.tag == "InterObjectHeal")
        {
            Health_Point += 10f;
            Debug.Log("HP restored = 10");
        }
    }
}
