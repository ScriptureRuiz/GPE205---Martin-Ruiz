using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this code creates a pawn class called TankPawn that inherits from the MasterPawn class
public class TankPawn : MainPawn
{
    // Start is called before the first frame update
    // This code overrides the start function within the "parent" class MainPawn
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();

    }


    // The following code overrides the movement functions within the "parent" class called MainPawn 
    public override void MoveForward()
        {
        if (mover != null)
        {
            mover.Move(transform.forward, moveSpeed);
        }
        else
        {
            Debug.LogWarning("Warning:No Mover in Tank.MoveForward");
        }
        }


    public override void MoveBackward()
        {
        if (mover != null)
        {
            mover.Move(transform.forward, -moveSpeed);
        }
        else
        {
            Debug.LogWarning("Warning: No Mover in Tank.MoveBackward");
        }
        }


    public override void RotateClockwise()
        {
        if (mover != null)
        {
            mover.Rotate(Vector3.up, turnSpeed);
        }
        else
        {
            Debug.LogWarning("Warning: No Mover in Tank.RotateClockwise");
        }
        }


        public override void RotateCounterClockwise()
        {
        if (mover != null)
        {
            mover.Rotate(Vector3.up, -turnSpeed);
        }
        else 
            {
            Debug.LogWarning("Warning: No Mover in Tank.CounterClockwise");
            }
        }


}
