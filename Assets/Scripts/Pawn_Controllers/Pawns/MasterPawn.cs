using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this component is abstract and can always be oveeridden
public abstract class MasterPawn : MonoBehaviour
{
    //This variable holds the move speed of the pawn
    public float moveSpeed;

    //This variable holds the rotation speed of the pawn
    public float rotationSpeed;

    // The Key word Virtual allows us to override the MasterPawn
   public virtual void Start()
    {
        
    }

    // The Key word Virtual allows us to override the MasterPawn
    public virtual void Update()
    {
        
    }
    //The following codes are abstract and can be overriden
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}
