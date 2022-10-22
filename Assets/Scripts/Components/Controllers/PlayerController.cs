using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is a child class of the MainController class.
// The [System.Serializable], allows us to expose this to the inspector
[System.Serializable]
public class PlayerController : MainController
{
    // The following are variables created to hold the movement values.
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;
    // Start is called before the first frame update
    // The following was made virtual, allowing us to override this function.
    public override void Start()
    {
        /* This is a nested conditional statement that checks to see if there is a GameManager
          and if so it tracks the player and registers it with the GameManager to keep the list up to date*/
        if (GameManager.instance !=null)
        {
            // if the Gamemanager tracks an instance of the player
            if (GameManager.instance.players !=null)
            {
                // Register an instance of the player with the gamemanager (add (this))
                GameManager.instance.players.Add(this);
            }
        }

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

    // The following codes are conditional statements that use the parent "processInputs()" method for moving the player from the MainMover
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
        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
    }


    // (players) List will stay up to date as we add or remove Player Controllers from the world! 
    public void OnDestroy()
    {// Checkes for GameManager
        if (GameManager.instance !=null)
        {//Checks for players list
            if (GameManager.instance.players !=null)
            {// Removes it from the list
                GameManager.instance.players.Remove(this);
            }
        }
    }

}