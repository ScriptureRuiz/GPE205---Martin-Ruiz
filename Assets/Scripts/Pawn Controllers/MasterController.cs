using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this component is abstract and can only be inherited from
public abstract class MasterPawn : MonoBehaviour
{
    //This variable holds the move speed of the pawn
    public float moveSpeed;

    //This variable holds the rotation speed of the pawn
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //The following code gives this parent class traits to "move" but cannot access them itself
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}
