using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase : MonoBehaviour
{
    public enum ClaseSelector
    {
        Guerrero,
        Mago,
        Arquero
    }

    public ClaseSelector claseSeleccionada;
    private void Start()
    {
        switch(claseSeleccionada)
        { 
        case ClaseSelector.Guerrero:
            break;
        case ClaseSelector.Mago:
            break;
        case ClaseSelector.Arquero:
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
