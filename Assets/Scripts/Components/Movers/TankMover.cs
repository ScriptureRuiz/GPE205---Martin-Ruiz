using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MainMover
{
    // This is a Rigidbody variable called rb that will hold our rigidbody component
    // this variable is private and is only accessed by this object
    private Rigidbody rb;

    public float turnSpeed;

    public float speed;

    private Vector3 rotateVector;


    // Start is called before the first frame update
    // Overrides the start function within the MainMover component
    public override void Start()
    {
        // We store the RigidBody component within the variable
        rb = GetComponent<Rigidbody>();
    }

    // Here we override the move function from the parent class "MainMover"
    public override void Move(Vector3 direction, float speed)
    {
        // Here we establish framerate independence for a vector3 variable "moveVector" (tf.position = tf.position + (myVector * speed * Time.deltaTime)) 
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;

        // Here we call our variable to move positions with the parameters (rb.position+moveVector)
        rb.MovePosition(rb.position+moveVector);
    }

    public override void Rotate(Vector3 up, float turnSpeed)
    {
        Vector3 rotateVector = up.normalized * turnSpeed * Time.deltaTime;

       rb.MovePosition(rb.position+rotateVector);

    }



}
