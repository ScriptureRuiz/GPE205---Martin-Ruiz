using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MainController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start(); 
    }


    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
        base.Update();
    }


    public void MakeDecisions()
    {
        Debug.Log("Thinking of Strategies");
    }

    public override void ProcessInputs()
    {

    }
}   
