using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AIController : MainController

{
    // Target that the ai attacks
    public GameObject target;
    public float fleeDistance;
   

    // All seek() variables
  /* public Vector3 targetPosition;
   public Transform targetTransform;
    public MainPawn targetPawn;
    public MainController targetController;*/


    // Stores all the possible states of the A.I as "enums"
    public enum AIState
    {
        Guard, Patrol, Scan, Chase, Attack, Flee
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

                if (IsDistanceLessThan(target, 15))
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
                else if (IsDistanceLessThan(target, 5))
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
      
         
    }

    protected virtual void DoAttackState()
    {
        pawn.Shoot();
    }

    protected virtual void DoFleeState()
    {
        Flee();
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

        //Polymorphism.base- Seeks the target object
    public virtual  void Seek(GameObject target)
    {
 
        // Rotates towards the target and grabs the targets transform and position
        pawn.RotateTowards(target.transform.position);

         //Moves towards the target
        pawn.MoveForward();
    }

   /* public void Seek(Vector3 targetPosition)
    {
        // Rotates towards the target position
        pawn.RotateTowards(targetPosition);
        // Moves forward
        pawn.MoveForward();
    }

        //PolyMorphism-Seeks the target transform
    public  void Seek(Transform targetTransform)
    {
       Seek(targetTransform.transform);

    }

        //Polymorphism- Seeks the target pawn
    public void Seek(MainPawn targetPawn)
    {

        Seek(targetPawn.transform);
    }

    //Polymorphism- seeks target controller
   public  void Seek(MainController targetController)
   {
       Seek(targetController.pawn); 
            

   }*/

    // Attacks the target
    protected void Attack()
    {
        //Shoot function
        pawn.Shoot();
    }
        // Flees the target
    protected void Flee()
    {
         /*****    // Finds the distance to the target
        Vector3 distanceToTarget = target.transform.position - pawn.transform.position;

             // Finds the vector away from our target by multiplying by -1
        Vector3 vectorAwayFromTarget = - distanceToTarget;
            // Find the vector we would travel down in order to flee
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
            // Seeks the fleevector point away from the targets position
       Seek(targetTransform.transform.position + fleeVector); ******/



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

    public bool CanHear(GameObject target)
    {
        // Grab the targets noise maker
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        // Only senses noise if the target has a noiseMaker
        if (noiseMaker.volumeDistance==null)
        {
            return false;
        }
       else if (noiseMaker.volumeDistance=0)
        {
            return false;
        }
        // If noise is being made then add the volumeDistance to the hearing distance of the AI
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;
        // If within the target distance then its true we can hear
        else if(Vector3.Distance(pawn.transform.position,target.transform.position)<=totalDistance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    public void OnDestroy()
    {// Checkes for GameManager
        if (GameManager.instance != null)
        {//Checks for players list
            if (GameManager.instance.enemies != null)
            {// Removes it from the list
                GameManager.instance.enemies.Remove(this);
            }
        }
    }




}   
