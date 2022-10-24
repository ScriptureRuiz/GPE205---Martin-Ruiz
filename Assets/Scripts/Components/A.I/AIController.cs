using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MainController
{
    public float distance;
   

    // Stores all the possible states of the A.I as "enums"
    public enum AIState
    {
        Idle, Patrol, Scan, Chase, Attack, Flee
    }

    // store the current state of the A.I
    public AIState currentState;
    public GameObject target;

 // Stores the last recorded time that the A.I changed states
    private float lastStateChangeTime;





    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

       

    }


    // Update is called once per frame
    public override void Update()
    {
       
        base.Update();

            switch (currentState)
                {
                case AIState.Idle:
                DoIdleState();

                if (IsDistanceLessThan = true)
                {
                    ChangeState(AIState.Chase);
                }
                   

                break;

                case AIState.Patrol:
                DoPatrolState();
                break;

                case AIState.Scan: 
                DoScanState();
                break;
                
                case  AIState.Chase:
                DoChaseState();
                    
                break;

                case AIState.Attack:
                DoAttackState();
                break;

                case AIState.Flee:
                DoFleeState();
                break;

                default:ChangeState(AIState.Idle);
                break;

               
                }
        



    }


    public override void ProcessInputs()
    {

    }

    

    //The following functions Handle the states of the ai
    // Handles changing the state of the A.I
    public virtual void ChangeState(AIState newState)
    {
        // Changes the current atate of the A.I
        currentState = newState;
        // Saves the time the state of the A.I Changed
        lastStateChangeTime = Time.time;

    }

    // These are the states that our AI goes into
    public void DoIdleState()
    {
        Idle();
    }

    public void DoPatrolState()
    {

    }

    public void DoScanState()
    {


    }

    public void DoChaseState()
    { 
    
         // Seeks out the target
            Seek(target);          
         
    }

    public void DoAttackState()
    {

    }

    public void DoFleeState()
    {

    }



    // These are the Action functions of our states
    public void Idle()
    {
        Debug.Log("Im Idle");
    }

    public void Patrol()
    {

    }

    public void Scan()
    {

    }

    public void Seek(GameObject target)
    {
 
        // Rotates towards the target and grabs the targets transform and position
        pawn.RotateTowards(target.transform.position);

         //Moves towards the target
        pawn.MoveForward();
    }

    public void Attack()
    {

    }

    public void Flee()
    {

    }



    // These are the Transition methods to our states
     protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        /* If the distance between this objects transform position and the targets transform position
         is less than the distance value then return true */
       
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <distance)
        {


            return true;
            
            

        }
        else
        {
            return false;
        }
        
        ChangeState(AIState.Chase);
       
    }










}   
