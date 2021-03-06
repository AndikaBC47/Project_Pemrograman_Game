using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public GameObject loadanim;
    public GameObject loadscreen;
    public Slider loadbar;
    public Text loadText;
    public static bool loadStat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void starto(int sceneIndex)
    {
        //oloadanim.SetActive(true);
        loadscreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStat = false;
        //SceneManager.LoadScene("SampleScene");
    }

    public void LoadSaveGame(int sceneIndex)
    {
        loadscreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStat = true;
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operate = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operate.isDone)
        {
            int progress = (int)Mathf.Clamp01(operate.progress / .9f);

            loadbar.value = progress;
            loadText.text = progress * 100 + "%";

            yield return null;
        }
    }

    public void endo()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Jika masih di Unity Editor
        //Application.Quit();
    }
}
