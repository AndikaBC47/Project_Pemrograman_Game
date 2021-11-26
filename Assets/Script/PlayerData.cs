using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] posisi;
    public int[] waktu;

    public PlayerData(Player player)
    {
        waktu = new int[3];
        posisi = new float[3];

        waktu[0] = EnviroSky.instance.GameTime.Hours;
        waktu[1] = EnviroSky.instance.GameTime.Minutes;
        waktu[2] = EnviroSky.instance.GameTime.Seconds;

        posisi[0] = player.transform.position.x;
        posisi[1] = player.transform.position.y;
        posisi[2] = player.transform.position.z;

    }
}
