using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RouletteWhell : MonoBehaviour
{
    [SerializeField] RouletteNumber[] rouletteNumbers;
  
    void Update()
    {
        transform.Rotate(new Vector3(0f,-1f,0f) * Time.deltaTime * 30f);
    }


    public Transform GetNumberTransform(byte targetNumber)
    {
        foreach (var item in rouletteNumbers)
        {
            if(item.number == targetNumber)
            {
                return item.gameObject.transform;
            }
        }

        return null;
    }


    


}
