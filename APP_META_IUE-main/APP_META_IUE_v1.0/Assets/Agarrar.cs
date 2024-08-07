using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrar : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    void Update()
    {
       
    }

    void OnMouseOver()
    {
        // Usa mouseScrollDelta para obtener el valor del scroll del mouse
        float scroll = Input.mouseScrollDelta.y;

        // Aplica la rotaci�n en el eje X (o el eje que prefieras)
        gameObject.transform.Rotate(0, scroll * 10, 0);
       
    }

        void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
       
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }
}
