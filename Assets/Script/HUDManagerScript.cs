using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManagerScript : MonoBehaviour
{ 
    public Image currentEnergy;
    private GameObject player;
    public Text time;

    public float energy = 200;
    private float energy_max = 200;
    private float speed;
    private float runspeed;
    private float input_x;
    private float input_z;
    void Start()
    {
        player = GameObject.Find("Player");
        runspeed = player.GetComponent<PlayerMovementScript>().runsped;
    }

    // Update is called once per frame
    void Update()
    {
        speed = player.GetComponent<PlayerMovementScript>().kecepatan;
        input_x = player.GetComponent<PlayerMovementScript>().x;
        input_z = player.GetComponent<PlayerMovementScript>().z;
        energy_drain();
        UpdateEnergy();
        UpdateTime();
    }

    private void energy_drain()
    {
       if (speed == runspeed)
        {
            if (input_x > 0 || input_z > 0)
            {
                if (energy > 0)
                {
                    energy -= 10 * Time.deltaTime;
                }
                else
                {
                    StartCoroutine(DelayAction());
                }
            }
            
        }
        else
        {
            if (energy < energy_max)
            {
                energy += 15 * Time.deltaTime;
                
            }
        }
    }

    IEnumerator DelayAction()
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSecondsRealtime(5.0f);
         
        //Do the action after the delay time has finished.
    }
    private void UpdateEnergy()
    {
        float ratio = energy / energy_max;

        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void UpdateTime()
    {
        int hours = EnviroSky.instance.GameTime.Hours;
        int minutes = EnviroSky.instance.GameTime.Minutes;
        string gameHours;
        string gameMinutes;

        if(hours >= 0 && hours < 10)
        {
            gameHours = "0" + hours.ToString();
        }
        else
        {
            gameHours = hours.ToString();
        }
        if (minutes >= 0 && minutes < 10)
        {
            gameMinutes = "0" + minutes.ToString();
        }
        else
        {
            gameMinutes = minutes.ToString();
        }

        time.text = gameHours + " : " + gameMinutes;
    }
}
