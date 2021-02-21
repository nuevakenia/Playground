using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public Item[] inventory;
    
    private ItemDB _itemDatabase;

    private void Start()
    {
        _itemDatabase = GameObject.Find("ItemDB").GetComponent<ItemDB>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _itemDatabase.AddItem(0, this);
        }
        else if(Input.GetKeyDown(KeyCode.T))
        {
            _itemDatabase.RemoveItem(0, this);
        }
    }
}
