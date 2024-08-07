using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Acople : MonoBehaviour
{
    public Transform puntoDeEncaje; // Asigna el transform del punto de encaje

    //public Acople ScriptAcople;

    public MeshFilter meshFilter;


    public bool fusionado;
    float x;
    float y;
    float z;
    private void OnCollisionEnter(Collision collision)
    {

    }

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Acople piezaCercana = other.GetComponent<Acople>();


        // Verifica si la pieza cercana es de un tipo diferente y si el punto de encaje no es nulo
        if (piezaCercana != null && other.name != this.name && piezaCercana.puntoDeEncaje != null)
        {

            Debug.LogWarning("Colisión detectada con pieza de tipo diferente");

            if (!fusionado)
            { return; }

            transform.rotation = piezaCercana.puntoDeEncaje.rotation;
            piezaCercana.transform.rotation = this.puntoDeEncaje.rotation;

            //transform.position = piezaCercana.puntoDeEncaje.position;
            piezaCercana.transform.position = this.transform.position;


          
            MeshFilter otherMeshFilter = other.GetComponent<MeshFilter>();

            // Crea una instancia de CombineInstance para cada malla
            CombineInstance[] combineInstances = new CombineInstance[2];
            combineInstances[0].mesh = meshFilter.sharedMesh;
            combineInstances[0].transform = transform.localToWorldMatrix;
            combineInstances[1].mesh = otherMeshFilter.sharedMesh;
            combineInstances[1].transform = other.transform.localToWorldMatrix;

            // Combina las mallas
            Mesh combinedMesh = new Mesh();
            combinedMesh.CombineMeshes(combineInstances, true);

            // Crea un nuevo GameObject para mostrar la malla combinada
            GameObject mergedObject = new GameObject("NuevaCombinacion");
            mergedObject.AddComponent<MeshFilter>().sharedMesh = combinedMesh;
            mergedObject.AddComponent<MeshRenderer>().material = meshFilter.GetComponent<MeshRenderer>().material;

            // propiedades heredadas

            // MeshCollider objeto1 = GetComponent<MeshCollider>();

            //creacion de malla.
            MeshCollider nuevoCollider = mergedObject.AddComponent<MeshCollider>();
            nuevoCollider.convex = true;

            //creacion de cuerpo rigido
            Rigidbody rigidbody = mergedObject.AddComponent<Rigidbody>();
            rigidbody.automaticInertiaTensor = true;
            rigidbody.inertiaTensor = new Vector3(0, 0, 0);
            rigidbody.mass = 10;
            rigidbody.isKinematic = false;

           
           
            ///////////////////////copia componentes del objeto colisionado 1 /////////////
           
            UnityEngine.Component[] componentes = this.GetComponents<UnityEngine.Component>();
            
            // Copia los componentes del otro objeto fuente al objeto destino
            System.Type tipoDeScriptBuscado = typeof(Acople);
            foreach (var componente in componentes)
            {
               
                // Evita copiar el Transform y los colliders nuevamente
                if (!(componente is Transform)  && !(componente is Collider))
                {
                    // Copia el componente al objeto destino
                    System.Type componentType = componente.GetType();
                    System.Type componentType3 = componente.GetType();//ensayo github

                    UnityEngine.Component compo =  mergedObject.AddComponent(componentType);

                    if (componentType == tipoDeScriptBuscado)
                    {
                        
                        Acople scriptnuevo = (Acople)compo;
                        scriptnuevo.puntoDeEncaje = this.puntoDeEncaje;
                        

                    }

                }
            }
            /////////hereda los objetos vacios del objeto 1 al objeto unido
            Transform[] vacios = this.GetComponentsInChildren<Transform>();
            
            foreach (Transform hijo in vacios)
            {
                // Crea un nuevo objeto vacío en el objeto destino que representara el punto de encaje
                Transform vacio;
                vacio = hijo;
                vacio.name = hijo.name;
                vacio.transform.SetParent(mergedObject.transform);
               
            }

            /////////////////////////////////////////////////////////////////////////////

            ///////////////////////copia componentes del objeto colisionado 2 /////////////
            UnityEngine.Component[] componentes2 = other.GetComponents<UnityEngine.Component>();

            // Copia los componentes del otro objeto fuente al objeto destino
            System.Type tipoDeScriptBuscado2 = typeof(Acople);
            foreach (var componente2 in componentes2)
            {

                // Evita copiar el Transform y los colliders nuevamente
                if (!(componente2 is Transform) && !(componente2 is Collider) && !(componente2 is Agarrar))
                {
                    // Copia el componente al objeto destino
                    System.Type componentType2 = componente2.GetType();


                    UnityEngine.Component compo2 = mergedObject.AddComponent(componentType2);

                    if (componentType2 == tipoDeScriptBuscado2)
                    {

                        Acople scriptnuevo2 = (Acople)compo2;
                        scriptnuevo2.puntoDeEncaje = piezaCercana.puntoDeEncaje;


                    }

                }
            }

            /////////hereda los objetos vacios del objeto 2 al objeto unido
           
            Transform[] vacios2 = other.GetComponentsInChildren<Transform>();

            foreach (Transform hijo2 in vacios2)
            {
                // Crea un nuevo objeto vacío en el objeto destino que representara el punto de encaje
                Transform vacio2;
                vacio2 = hijo2;
                vacio2.name = hijo2.name;
                vacio2.transform.SetParent(mergedObject.transform);

            }

            ////////////////////////////////////////////////////////////////////////////////



            //foreach (Transform child in other.transform)
            //{
            //    // Crea un nuevo objeto vacío en el objeto destino que representara el punto de encaje
            //    Transform emptyObject;
            //    emptyObject = child;
            //    emptyObject.name = child.name;
            //    emptyObject.transform.SetParent(mergedObject.transform);

            //}

            ////////////////////////////////////////////////////////////////////////////////

            //nuevo = objeto1;
            // BoxCollider boxCollider = mergedObject.AddComponent<BoxCollider>();
            // boxCollider.center = new Vector3(1,1,1);


            // Destruye los GameObjects originales
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
   
} 


