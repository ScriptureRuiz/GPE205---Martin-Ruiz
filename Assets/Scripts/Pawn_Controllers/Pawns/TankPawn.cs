using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this code creates a pawn class called TankPawn an inherits from the MasterPawn class
public class TankPawn : MasterPawn
{
    // Start is called before the first frame update
    // This code overrides the start function
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }
    // The following code overrides the MasterPawn and runs a Test Stub
    public override void MoveForward()
        {
        Debug.Log ("Move Forward");
        }
    public override void MoveBackward()
        {
        Debug.Log("Move Backward");
        }
    public override void RotateClockwise()
        {
        Debug.Log("Rotate Clockwise");

        }
        public override void RotateCounterClockwise()
        {
        Debug.Log("Rotate Counter-Clockwise");

        }


}
