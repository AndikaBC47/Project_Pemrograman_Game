using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (StartGameScript.loadStat)
        {
            LoadPlayer();
        }
    }

    private void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.posisi[0];
        position.y = data.posisi[1];
        position.z = data.posisi[2];

        EnviroSky.instance.SetTime(1, 1, data.waktu[0], data.waktu[1], data.waktu[2]);
       
        transform.position = position;
    }


}
