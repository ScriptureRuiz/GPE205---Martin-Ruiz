using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this code creates a pawn class called TankPawn that inherits from the MasterPawn class
public class TankPawn : MainPawn
{
    // The following variables apply to the prefab Shoot() function
    public GameObject bulletPrefab;
   public float fireForce;
   public float damageDealt;
   public float bulletLifespan;

    // These are variables for a rate of fire using the are we there yet timer method
    public float fireRate;
    private float nextFire;

    // Start is called before the first frame update
    // This code overrides the start function within the "parent" class MainPawn
    public override void Start()
    {
        base.Start();
        /* Initializing the timer by making the next fire time equel  to
         the time since start +  and delay time
        The firRate is divided by one to make the rate of fire shots per second instead of seconds between shots*/
        nextFire = Time.time +1/fireRate;
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
            mover.Rotate(turnSpeed);
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
            mover.Rotate(-turnSpeed);
        }
        else 
            {
            Debug.LogWarning("Warning: No Mover in Tank.CounterClockwise");
            }
        }

    public override void Shoot()
    { 
        // Checks if the time since start has reached the nextFire time
        if(Time.time > nextFire)
        { 
           

           
             if (shooter !=null)
                { 
                    shooter.Shoot(bulletPrefab, fireForce, damageDealt, bulletLifespan);
                }
           // Resets the timer to record the current time and repeats the
           // timer process of checking if were there yet 
           nextFire = Time.time+1/fireRate;
            
    }   }
}
