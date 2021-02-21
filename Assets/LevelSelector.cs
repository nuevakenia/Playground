using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour
{
        [SerializeField]
    public enum Level
    {
        SplashScreen, // 0
        Level1, // 1
        Level2, // 2
        Level3, // 3
    }

    public Level lvl;
    void Start()
    {
        
    }

    public void ObtenerBoton()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        string buttonId = buttonName.Substring(buttonName.Length - 1);
        SelectLevel(buttonId);
        print("Apretaste el boton con nombre: "+ buttonName);
        print("Apretaste el boton con ID: " + buttonId);
    }    


    public void SelectLevel(string buttonId)
    {
        
        switch (lvl)
        {
            case Level.SplashScreen:
            SceneManager.LoadScene(int.Parse(buttonId));
                print("CASE Apretaste el boton con ID: " + buttonId);
                break;
            case Level.Level1:
            SceneManager.LoadScene(int.Parse(buttonId));
                print("CASE Apretaste el boton con ID: " + buttonId);
                break;
            case Level.Level2:
            SceneManager.LoadScene(int.Parse(buttonId));
                print("CASE Apretaste el boton con ID: " + buttonId);
                break;
            case Level.Level3:
            SceneManager.LoadScene(int.Parse(buttonId));
                print("CASE Apretaste el boton con ID: " + buttonId);
                break;
        }    
        
    }

}
