using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a child class of the MainController class.
public class PlayerController : MainController
{
    // The following are variables created to hold the movement values.
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;

    // Start is called before the first frame update
    // The following was made virtual, allowing us to override this function.
    public override void Start()
    {
        // The following code runs the base "Start" function that is in the parent class.
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // This code processes the input method from the parent classes.
        ProcessInputs();

        //This code runs the update base function from the parent class.
        base.Update();
    }
    // The following codes are conditional statements that use the parent "processInputs()" method.
    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
    }
}