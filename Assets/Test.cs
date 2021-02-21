using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> objetos = new List<GameObject>();
    public List<GameObject> objetosSpawneados = new List<GameObject>();

    // public GameObject jimmy;
    public GameObject juan;
    public GameObject pedro;
    // Start is called before the first frame update
    void Start()
    {
        /* foreach (GameObject i in items) // “i” sería cada iteración de enemigo
         {
             print("Item: " + i);
         } */
     }

     // Update is called once per frame
     void Update()
     {
         if (Input.GetKeyDown("r"))
         {
             foreach (GameObject obj in objetos) // “i” sería cada iteración de enemigo
             {
                if (objetosSpawneados.Count < 10)
                { 
                 GameObject instancia = Instantiate(obj);
                 var randomPos = Random.Range(-10, 10);
                 instancia.transform.position = new Vector3(randomPos, randomPos, 0);
                 print("Objeto de nombre: " + obj + " spawneado");
                 objetosSpawneados.Add(instancia);
                }
                else
                {
                    CambiarColor();
                    
                }
                    
                   
                 
            }

             /*
             foreach (GameObject i in items) // “i” sería cada iteración de enemigo
             {
                 print("Item: " + i);
             }


             items.RemoveAt(Random.Range(0, items.Count));
             foreach (GameObject i in items) // “i” sería cada iteración de enemigo
             {
                 print("Item: " + i);
             }
             */
    }

         void CambiarColor()
        {
            foreach (GameObject objspawn in objetosSpawneados)
            {
                var renderobj = objspawn.GetComponent<Renderer>();
                renderobj.material.SetColor("_Color", Color.green);

            }
            objetosSpawneados.Clear();
        }
}
}

// spawnear 3 objetos desde una lista en posiciones random entre -10 y +10 en el eje X / Y al presionar R, cuando 
// se spawnee un objeto tiene que almacenarse en la lista, cuando spawnees 10 objetos, tirar error de maximo, y convertir todos
// los objetos en color verde y limpiar la lista.
