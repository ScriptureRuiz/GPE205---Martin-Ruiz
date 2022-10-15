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
    // The following code overrides the movement functions within the "parent" class called MainPawn and runs a Test Stub
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
