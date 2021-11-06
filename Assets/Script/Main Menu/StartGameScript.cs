using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public GameObject loadanim;
    void Start()
    {
        loadanim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void starto()
    {
        loadanim.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }
}
