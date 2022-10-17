using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Singleton GameManager
public class GameManager : MonoBehaviour
{
    /*Here we create a GameManager variable called instances.
     Static means that we can access our single instance of the class from anywhere.
     This variable will point back at this component when storing data in this variable */
    public static GameManager instance;

   // This will run before any start() function in our game
   // Whatever code we write here will run before any object can run their start() function
   private void Awake()
    {
        /* This conditional statement checks to see if another GameManeger
           object exist and destroys it if so*/
        if (instance==null)
        {
          //This variable will point back at this component when storing data in this variable
           instance = this;
            // This will keep our GameManager from getting destroyed when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // There is already an instance, so destroy this gameObject
            Destroy(gameObject);
        }

    }
}
