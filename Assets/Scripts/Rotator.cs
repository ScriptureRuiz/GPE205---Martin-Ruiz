using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Rigidbody heart;
    public float turnSpeed;

    public void Start()
    {
    heart = GetComponent<Rigidbody>();

    }
    public void Update()
    {
        

    }

 public void Rotate(float turnSpeed)
    {
    Vector3 rotate = new Vector3(0, turnSpeed * Time.deltaTime);
    heart.transform.Rotate(rotate);

    }
}

