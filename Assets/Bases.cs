using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bases : MonoBehaviour
{
    private bool isGameOver;


    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
        set
        { 
            if (value == true)
            {
                Debug.Log("Oh no perdiste!!");
                SceneManager.LoadScene(0);
            }
            isGameOver = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        
    }
}
