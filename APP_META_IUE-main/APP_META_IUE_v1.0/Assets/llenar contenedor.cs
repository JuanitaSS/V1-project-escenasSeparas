using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llenarcontenedor : MonoBehaviour
{
    public GameObject fichaPrefab; // Asigna tu prefab de la ficha en el Inspector
    public float cantidadFichas; // Cantidad de fichas a crear
    public float alturaInicial = 10f; // Altura desde la cual las fichas caer�n
    public TextMesh Numero;

    void Start()
    {
        if (float.TryParse(Numero.text, out float parsedNumber))
        {
            //   Debug.Log($"N�mero le�do: {parsedNumber}");
            cantidadFichas = parsedNumber;    
        }
        else
        {
            Debug.LogWarning("El texto no representa un n�mero v�lido.");
        }

        for (int i = 0; i < cantidadFichas; i++)
        {
            // Calcula una posici�n aleatoria para cada ficha
            Vector3 posicionAleatoria = new Vector3(Random.Range(-5f, 5f), alturaInicial, Random.Range(-5f, 5f));
            // Instancia la ficha y deja que la f�sica tome el control
            Instantiate(fichaPrefab, posicionAleatoria, Quaternion.identity);
        }
    }
}

