using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteWhell : MonoBehaviour
{
   
    void Update()
    {
        transform.Rotate(new Vector3(0f,0f,1f) * Time.deltaTime * 30f);
      
    }
}
