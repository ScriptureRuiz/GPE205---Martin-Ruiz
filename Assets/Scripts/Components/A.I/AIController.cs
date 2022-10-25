using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MainController
{
    public float fleeDistance;
   

    // Stores all the possible states of the A.I as "enums"
    public enum AIState
    {
        Guard, Patrol, Scan, Chase, Attack, Flee
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
    // The Decision Maker
    public void MakeDecisions()
    {
        switch (currentState)
        {
            case AIState.Guard:
                DoGuardState();

                if (IsDistanceLessThan(target, 10))
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

            case AIState.Chase:
                DoChaseState();
                if (!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Guard);
                }
                break;

            case AIState.Attack:
                DoAttackState();
                break;

            case AIState.Flee:
                DoFleeState();
                break;

            default:
                ChangeState(AIState.Guard);
                break;
        }

    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        MakeDecisions();
   
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
    protected virtual void DoGuardState()
    {
        Guard();
    }

    protected virtual void DoPatrolState()
    {

    }

    protected virtual void DoScanState()
    {


    }

    protected virtual void DoChaseState()
    { 
    
         // Seeks out the target
            Seek(target);          
         Attack();
    }

    protected virtual void DoAttackState()
    {

    }

    protected virtual void DoFleeState()
    {
        Flee();
    }



    // These are the Action functions of our states
    protected virtual void Guard()
    {
        Debug.Log("Im Idle");
    }

    protected virtual void Patrol()
    {

    }

    protected virtual void Scan()
    {

    }

        //Polymorphism.base- Seeks the target object
    public  void Seek(GameObject target)
    {
 
        // Rotates towards the target and grabs the targets transform and position
        pawn.RotateTowards(target.transform.position);

         //Moves towards the target
        pawn.MoveForward();
    }

        //PolyMorphism-Seeks the target transform
    public void Seek(Transform targetTransform)
    {
        Seek(targetTransform.transform);

    }

        //Polymorphism- Seeks the target pawn
    public void Seek(MainPawn targetPawn)
    {

        Seek(targetPawn.transform);
    }

    //Polymorphism- seeks target controller
    //public  void Seek(Controller targetController)
    //{ 
    //    Seek(targetController.Controller);
    //}

    // Attacks the target
    public void Attack()
    {
        //Shoot function
        pawn.Shoot();
    }
        // Flees the target
    protected void Flee()
    {
             // Finds the distance to the target
        Vector3 distanceToTarget = target.transform.position - pawn.transform.position;

             // Finds the vector away from our target by multiplying by -1
        Vector3 vectorAwayFromTarget = -distanceToTarget;
            // Find the vector we would travel down in order to flee
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
            // Seeks the fleevector point away from the targets position
        Seek(pawn.transform.position + fleeVector);



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
        
        
       
    }










}   
