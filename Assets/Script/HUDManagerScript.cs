using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    //PAUSE MENU
    [SerializeField] GameObject pause_menu;
    public static bool isPaused;
    [SerializeField] GameObject musicStat;
    [SerializeField] GameObject stat_panelsave;

    //HUD Save System
    public Player playerInstance;

    //HUD Damage System
    private float HP;
    private float maxHP = 100f;
    public Image currentHP;
    void Start()
    {
        player = GameObject.Find("Player");
        runspeed = player.GetComponent<PlayerMovementScript>().runsped;
        musicStat = GameObject.Find("music");
        //stat_panelsave = GameObject.Find("pnl_notif_save");
    }

    // Update is called once per frame
    void Update()
    {
        HP = player.GetComponent<HPSystem>().Health_Point;

        speed = player.GetComponent<PlayerMovementScript>().kecepatan;
        input_x = player.GetComponent<PlayerMovementScript>().x;
        input_z = player.GetComponent<PlayerMovementScript>().z;
        energy_drain();
        UpdateEnergy();
        UpdateTime();
        PausedON();
        UpdateHP();
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

    private void PausedON()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
                
            }
            else
            {
                pause();
                
            }
        }
    }

    public void resume()
    {
        pause_menu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        musicStat.GetComponent<AudioSource>().volume = 0.153f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void pause()
    {
        pause_menu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        musicStat.GetComponent<AudioSource>().volume = 0;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void exit()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Jika masih di Unity Editor
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayer(playerInstance);
        stat_panelsave.SetActive(true);
        stat_panelsave.transform.LeanScale(Vector2.one, 0.8f);
    }

    public void panelsave()
    {
        stat_panelsave.transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
        stat_panelsave.SetActive(false);
        
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    private void UpdateHP()
    {
        float ratio = HP / maxHP;
        currentHP.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}
