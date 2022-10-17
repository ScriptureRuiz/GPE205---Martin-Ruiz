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
    /* A variable that shows in the inspector that allows us to connect our spawner gameObject to spawn the player.
        We will also use the transform of this object for position*/
    public Transform playerSpawnTransform;
    // This will run before any start() function in our game
    // Whatever code we write here will run before any object can run their start() function
    private void Awake()
    {
        /* This conditional statement checks to see if another GameManeger
           object exist and destroys it if so*/
        if (instance == null)
        {
            //This variable will point back at this component when storing data in this variable
            instance = this;
            // This will keep our GameManager from getting destroyed when loading a new scene
            DontDestroyOnLoad(gameObject);
            // Here we spawn in the player controller at (0,0,0) and no rotation
            GameObject newplayerObj = Instantiate(PlayerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            /* Instantiats is when you create a new object in C# for a class using the new keyword
              It spawns a tankPawn from the prefab at the player spawn transform position and gives it the player spawn transform rotation and makes it a game object*/
            GameObject newPawnObj = Instantiate(TankPawnPrefab,playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        }
        else
        {
            // There is already an instance, so it destroys this gameObject
            Destroy(gameObject);
        } }

 
   


 //Prefabs
    public GameObject PlayerControllerPrefab;
    public GameObject TankPawnPrefab;

       

    
}
