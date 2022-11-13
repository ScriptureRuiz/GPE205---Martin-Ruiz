using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AIController : MainController

{
    // Target that the ai attacks
    public GameObject target;
    

    


    

    // Stores all the possible states of the A.I as "enums"
    public enum AIState
    {
        Guard, Patrol, Scan, Chase, Attack, Flee,ChooseTarget
    }

    // store the current state of the A.I
    public AIState currentState;
    

 // Stores the last recorded time that the A.I changed states
    private float lastStateChangeTime;

// Start is called before the first frame update
    public override void Start()
    {
        if (GameManager.instance != null)
        {
            // if the Gamemanager tracks an instance of the player
            if (GameManager.instance.enemies != null)
            {
                // Register an instance of the player with the gamemanager (add (this))
                GameManager.instance.enemies.Add(this);
            }
        }
 
        base.Start();
    }

    // The Decision Maker
    public virtual void MakeDecisions()
    {
        switch (currentState)
        {
            case AIState.Guard:
                DoGuardState();
                DoChooseTarget();
     
               if (IsDistanceLessThan(target,20))
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
                else if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Attack);
                }
                break;

            case AIState.Attack:
                DoAttackState();
                if (!IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIState.Chase);
                }
                break;

                break;
            case AIState.Flee:
                DoFleeState();
                break;

            case AIState.ChooseTarget:
                DoChooseTarget();
                
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
      
         
    }

    protected virtual void DoAttackState()
    {
        pawn.Shoot();
    }

    protected virtual void DoFleeState()
    {
        Flee();
    }

    protected virtual void DoChooseTarget()
    {
        TargetPlayerOne();
    }




    // These are the Action functions of our states
    protected virtual void Guard()
    {
         
    }
    protected virtual void Patrol()
    {

    }
    protected virtual void Scan()
    {

    }
       // Seeks the target object
    public virtual  void Seek(GameObject target)
    {
 
        // Rotates towards the target and grabs the targets transform and position
        pawn.RotateTowards(target.transform.position);

         //Moves towards the target
        pawn.MoveForward();
    }
   
    protected void Attack()
    {
        //Shoot function
        pawn.Shoot();
    } 
    protected void Flee()
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

    }

    

     public void TargetPlayerOne()
    {
        // Checks for a Game Manager
        if (GameManager.instance !=null)
        { 
            // Checks for a player array instance
            if (GameManager.instance.players !=null)
            { 
                // Counts how many players are within the array
                if(GameManager.instance.players.Count>0)
                {
                   
                    // Targets the Gameobject of the first player within the array
                    target=GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }

     protected bool HasTarget()
    {
        // Returns whether or not we have a target already
        return target != null;
    }

    

    // GameManager remove on destroy
    public void OnDestroy()
    {
    // Checkes for GameManager
        if (GameManager.instance != null)
        {//Checks for players list
            if (GameManager.instance.enemies != null)
            {// Removes it from the list
                GameManager.instance.enemies.Remove(this);
            }
        }
       
    }


}