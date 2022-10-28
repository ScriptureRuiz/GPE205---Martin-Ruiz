using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    
    public float turnSpeed;

    public void Start()
    {
    
    }
    public void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

    }

    
}
