using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class CambiarContenedor : MonoBehaviour
{
    //float x = 0;
    //float y = 0;
    //float z = 0;

    public string nombreDelcontenedor;
    public string nuevoContenedor;
    public string figurita;
    public string objetovacio;
    List<string> contenedores = new List<string>();
    List<string> tiposContenedores = new List<string>();
    List<string> figuras = new List<string>();
    List<string> Creadores = new List<string>();
    
    int i = 0;
    int j = 0;

    public GameObject Bandeja;
    // Start is called before the first frame update
    void Start()
    {
        contenedores.Add("Contenedor 1");
        contenedores.Add("Contenedor 2");
        contenedores.Add("Contenedor 3");
        contenedores.Add("Contenedor 4");
        contenedores.Add("Contenedor 5");
        contenedores.Add("Contenedor 6");
        contenedores.Add("Contenedor 7");

        tiposContenedores.Add("ContenedorTipo2");
        tiposContenedores.Add("ContenedorTipo3");
        tiposContenedores.Add("ContenedorTipo4");
        tiposContenedores.Add("ContenedorTipo5");


        //figuras.Add("figura 1");
        //figuras.Add("figura 2");
        //figuras.Add("figura 3");
        //figuras.Add("figura 4");
        //figuras.Add("figura 5");
        //figuras.Add("figura 6");
        //figuras.Add("figura 7");

        //Creadores.Add("Objeto1");
        //Creadores.Add("Objeto2");
        //Creadores.Add("Objeto3");
        //Creadores.Add("Objeto4");
        //Creadores.Add("Objeto5");
        //Creadores.Add("Objeto6");
        //Creadores.Add("Objeto7");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
        if (i < tiposContenedores.Count)
        {
            nuevoContenedor = tiposContenedores[i];

            foreach (var contenedor in contenedores)
            {
                //figurita = figuras[j];
                //objetovacio = Creadores[j];

                nombreDelcontenedor = contenedor;

                // Encuentra el GameObject por nombre
                GameObject objetoEncontrado = GameObject.Find(nombreDelcontenedor);
                GameObject objetoNuevo = GameObject.Find(nuevoContenedor);


                if (objetoEncontrado != null)
                {
                    // Obtiene el mesh del prefab original
                    //Mesh originalMesh = objetoNuevo.GetComponent<MeshFilter>().sharedMesh;

                    GameObject nuevoObjeto = Instantiate(objetoNuevo, objetoEncontrado.transform.position, objetoEncontrado.transform.rotation);
                    Destroy(objetoEncontrado);
                    nuevoObjeto.name = objetoEncontrado.name;
                    //GameObject objetoCreador = GameObject.Find(objetovacio); 

                    //Vector3 posicionBuscada = nuevoObjeto.transform.position;

                    //x = posicionBuscada.x;
                    //y = posicionBuscada.y;
                    //z = posicionBuscada.z;

                    //GameObject Parte = GameObject.Find(figurita); // encuetra la figura de esa posision

                    //GameObject Hijo = Instantiate(Parte, nuevoObjeto.transform);

                    //Hijo.transform.position = new Vector3(x + 0.05f, y + 0.1f, z + 0.08f);

                    //objetoCreador.transform.position = new Vector3(x+0.05f,y+0.1f,z+0.08f);


                    //Parte.transform.SetParent(nuevoObjeto.transform, false); // Mantiene la posición local relativa al padre

                    // Ajusta la posición del objeto "Parte" 
                    //Vector3 offset = new Vector3(0f, 1f, 0f); // Ajusta según tus necesidades
                    //fParte.transform.localPosition += offset;


                    // Asigna el mesh al objeto clonado
                    //objetoEncontrado.GetComponent<MeshFilter>().sharedMesh = originalMesh;



                    // Copia otros componentes personalizados si los tienes

                    // Elimina el GameObject original
                    //Destroy(objetoEncontrado);

                }

                else
                {
                    Debug.LogWarning($"No se encontró ningún objeto con el nombre {nombreDelcontenedor}.");
                }
                j++;
            }
            i++;
        }
        else
        {
            i = 0;
        }
    }
}
