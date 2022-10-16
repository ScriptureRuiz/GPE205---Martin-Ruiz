using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code creats a abstract class called "MainPawn" that will not be called, but will be overriden by its child class.
public abstract class MainPawn : MonoBehaviour
{
    // Variable for move speed
    public float moveSpeed;
    // Variable for turn speed
    public float turnSpeed;
    // Variable for the mover
    public MainMover mover;

    // Start is called before the first frame update
    // The start and update functions are "virtual" so we can override them within the child classes.
    public virtual void Start()
    {
        mover = GetComponent<MainMover>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }
    // The following code are abstract movement functions that allow us to override them within the child classes
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}