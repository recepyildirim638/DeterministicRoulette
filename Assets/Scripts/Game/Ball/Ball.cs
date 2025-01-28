using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float radius = 5f; 
    public float speed = 1f; 

    private float angle = 0f;

    void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        float y = 0.445f; 

        transform.localPosition = new Vector3(x, y, z);
    }
}
