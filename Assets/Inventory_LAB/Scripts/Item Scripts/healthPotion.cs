using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/HP-Potion")]
public class healthPotion : Item
{
    public float healingAmount;
    private GameObject player;
    
    void start()
    {
        player = GameObject.Find("Player");
    }
    public override void Use()
    {
        base.Use();
        //tambah darah
        float currHealth = player.GetComponent<HPSystem>().Health_Point;
        Debug.Log("HP Player = " + currHealth);
        currHealth += healingAmount;
        Debug.Log("Player receive healing from potion : +" + healingAmount);
        Debug.Log("HP Player : " + currHealth);

        //float currHealth = PlayerPrefs.GetFloat("Health_Point");
        //currHealth += healingAmount;
        //Debug.Log(currHealth);
        //PlayerPrefs.SetFloat("Health_Point", currHealth);

        //kurangin dari inventory
        RemoveFromInventory();
    }
}
