using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code creats an abstract class component "MonoBehaviour" called MainController
// The [System.Serializable], allows us to expose this to the inspector
[System.Serializable]
public abstract class MainController : MonoBehaviour
{
    // This is a public variable called MainPawn that holds our pawn values
    public MainPawn pawn;

    // The following code is "virtual", allowing us to override them in another class 
    // Note-Abstract will not be called but can be overriden, while virtual can be called and overriden
    // Start is called before the first frame update
    public virtual void Start()
    {
    }
    // Update is called once per frame
    public virtual void Update()
    {
    }
    /* This is an abstract class that allows us to override the inputs within the child classes and must be
     used with the same "ProcessInputs()" function within the child classes*/ 
    public abstract void ProcessInputs();
}
