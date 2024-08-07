using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class click : MonoBehaviour
{
    float x = 0;
    float y = 0;
    float z = 0;
  
    public string nombreDelObjeto; // Nombre del GameObject
    public Creador miScript; // Asigna el componente desde el Inspector
    public Agarrar Script2;

    public string contenedor;

    List<string> objetos = new List<string>();
    List<string> contenedores = new List<string>();

    int i = 0;
    private void Start()
    {
        contenedores.Add("Contenedor 1");
        contenedores.Add("Contenedor 2");
        contenedores.Add("Contenedor 3");
        contenedores.Add("Contenedor 4");
        contenedores.Add("Contenedor 5");
        contenedores.Add("Contenedor 6");
        contenedores.Add("Contenedor 7");

        objetos.Add("Objeto1");
        objetos.Add("Objeto2");
        objetos.Add("Objeto3");
        objetos.Add("Objeto4");
        objetos.Add("Objeto5");
        objetos.Add("Objeto6");
        objetos.Add("Objeto7");
    }

    void OnMouseDown()
    {

        foreach (var objeto in objetos)
        {
            nombreDelObjeto = objeto;
            contenedor = contenedores[i];

            // Encuentra el GameObject por nombre
            GameObject objetoEncontrado = GameObject.Find(nombreDelObjeto);

             if (objetoEncontrado != null)
            {
                GameObject Container = GameObject.Find(contenedor);

                if (Container != null)
                {
                    Vector3 posicionBuscada = Container.transform.position;
                    x = posicionBuscada.x;
                    y = posicionBuscada.y;
                    z = posicionBuscada.z;

                    objetoEncontrado.transform.position =new Vector3 (x,y + 0.2f,z + 0.02f);
                }
                // Habilita el script en el objeto encontrado
                miScript = objetoEncontrado.GetComponent<Creador>();
                miScript.enabled = true;

                Script2 = Container.GetComponent<Agarrar>();
                Script2.enabled = false;

            }
           
            else
            {
                Debug.LogWarning($"No se encontró ningún objeto con el nombre {nombreDelObjeto}.");
            }
            i++;
                }
    }
}




