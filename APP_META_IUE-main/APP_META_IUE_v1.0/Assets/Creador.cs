using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Analytics;

public class Creador : MonoBehaviour
{
    public bool inicio = false;
    public GameObject Pieza; // Asigna aquí el prefab de la esfera en el Inspector de Unity
    public float Cantidad; // Número total de esferas a generar
    public float Intervalo = 1.0f; // Intervalo en segundos entre cada esfera
    public Vector3 Area; // Define el área de generación para variar la posición

    private int spawnedSpheres = 0; // Contador de esferas generadas

    public TextMesh Numero;

    void Start()
    {
        StartCoroutine(SpawnSpheres());

    }
    
    IEnumerator SpawnSpheres()
    {
        if (float.TryParse(Numero.text, out float parsedNumber))
        {
            //   Debug.Log($"Número leído: {parsedNumber}");
            Cantidad = parsedNumber;
        }
        else
        {
            Debug.LogWarning("El texto no representa un número válido.");
        }

        while (spawnedSpheres < Cantidad)
        {
            // Genera una posición aleatoria dentro del área definida
            Vector3 randomPosition = new Vector3(
                Random.Range(-Area.x / 2, Area.x / 2),
                Random.Range(-Area.y / 2, Area.y / 2),
                Random.Range(-Area.z / 2, Area.z / 2)
            ) + transform.position;

            // Instancia la esfera en la posición aleatoria
            GameObject sphere = Instantiate(Pieza, randomPosition, Quaternion.identity);

            //Aplica una fuerza aleatoria para variar la caída
            Rigidbody rb = sphere.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(
                Random.Range(-1, 1), // Fuerza en X
                0,                    // Fuerza en Y (gravedad se encarga de esto)
                Random.Range(-1, 1) // Fuerza en Z
            ));

            spawnedSpheres++;
            yield return new WaitForSeconds(Intervalo);
        }
    }
}
