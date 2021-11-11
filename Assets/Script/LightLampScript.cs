using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Andika Budi Cahyadi NRP 152018011
public class LightLampScript : MonoBehaviour
{
    float time;
    GameObject[] allamp;
    void Start()
    {
        allamp = GameObject.FindGameObjectsWithTag("LampuKampung");

    }

    // Update is called once per frame
    void Update()
    {
        time = EnviroSky.instance.GameTime.Hours;  
        
        if (time < 18 && time > 6)
        {
            foreach(GameObject i in allamp)
            {
                i.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject i in allamp)
            {
                i.SetActive(true);
            }
        }
    }
}
