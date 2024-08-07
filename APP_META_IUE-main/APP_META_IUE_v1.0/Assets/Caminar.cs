using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    public float lookSpeed = 100.0f; // Velocidad de mirar arriba y abajo

    private float pitch = 0.0f; // Rotación en el eje x
   // private float jaw = 0.0f; // Rotación en el eje y
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

        // Controles de rotación izquierda y derecha con teclado
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Controles para mirar arriba y abajo con teclas del teclado
        if (Input.GetKey(KeyCode.F))
        {
            pitch += lookSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.R))
        {
            pitch -= lookSpeed * Time.deltaTime;
        }

        pitch = Mathf.Clamp(pitch, -45.0f, 45.0f); // Limita la rotación para no dar vueltas completas
        Camera.main.transform.localEulerAngles = new Vector3(pitch, transform.eulerAngles.y, 0.0f);

        // Controles para mirar arriba y abajo con mouse
        //pitch -= Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
        //pitch = Mathf.Clamp(pitch, -90.0f, 90.0f); // Limita la rotación para no dar vueltas completas
        ////Camera.main.transform.localRotation = Quaternion.Euler(pitch, 0.0f, 0.0f);

        //// Controles para mirar izquierda y derecha con mouse
        //jaw += Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        //jaw = Mathf.Clamp(jaw, -90.0f, 90.0f); // Limita la rotación para no dar vueltas completas
        //Camera.main.transform.localRotation = Quaternion.Euler(pitch, jaw, 0.0f);
    }
}
