using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public List<Item> itemDatabase = new List<Item>();

    public void AddItem(int itemID, PlayerItems player)
    {
        foreach(var item in itemDatabase)
        {
            if(item.id == itemID)
            {
                Debug.Log("Encontramos el item!");

                //checkear si hay espacio en el inventario
                player.inventory[0] = item;
                return;
            }
        }

        Debug.Log("El item no Existe!");
    }   
    
    public void RemoveItem(int itemID, PlayerItems player)
    {
        foreach(var item in itemDatabase)
        {
            if(item.id == itemID)
            {
                player.inventory[0] = null;

            }
        }    
    }
}
