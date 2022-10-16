using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainMover : MonoBehaviour
{

   

    // Start is called before the first frame update
    // Start is made to be abstract so the child class can override it, this will never be called, only overriden
    public abstract void Start();

    // This is an abstract function for moving that uses vector and float perameters
    public abstract void Move(Vector3 direction, float speed);

    // This is an abstract Rotate() function that takes a turnspeed float parameter
    public abstract void  Rotate(float turnSpeed);


    











}