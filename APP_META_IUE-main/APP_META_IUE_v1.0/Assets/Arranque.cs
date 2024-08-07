using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranque : MonoBehaviour
{
    
   public void cambiar()
    {
        Creador crear = GameObject.Find("Objeto1").GetComponent<Creador>();
        crear.gameObject.SetActive(true);
    }
  
   
}
