using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This is the physical object that will be picked up within the game
public class HealthPickup : MonoBehaviour
{
    // Holds the data for the powerups our tanks will get when triggered
    public HealthPowerUp powerup;










    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // The PowerupManager adds the powerup that is assosiated with this pickup
    public void OnTriggerEnter(Collider other)
    {
        // This variable stores the other objects Powerup controller
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // Checks to see if the other object has a powerup controller
        if (powerupManager != null)
        {
            // Adds the powerup 
            powerupManager.Add(powerup);
            Debug.Log("It should destroy");
            // Destroys the powerup
            Destroy(gameObject);
        }



    }










}
