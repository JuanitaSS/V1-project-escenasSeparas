using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disminuirCantidad : MonoBehaviour
{
    public float cantidad;
    public TextMesh Numero;

    // Start is called before the first frame update
    void Start()
    {
        //Numero = GetComponent<TextMesh>();     
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //string textValue = Numero.text;
        // Debug.Log($"Valor del texto: {textValue}");

        if (float.TryParse(Numero.text, out float parsedNumber))
        {
            //   Debug.Log($"Número leído: {parsedNumber}");
            parsedNumber--;
            Numero.text = parsedNumber.ToString();
        }
        else
        {
            Debug.LogWarning("El texto no representa un número válido.");
        }



    }
}
