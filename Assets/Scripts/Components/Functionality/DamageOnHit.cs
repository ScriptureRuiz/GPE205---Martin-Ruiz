using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{

    public float damageDealt;
    public MainPawn owner;


    // Deals damage when it is triggered on collision
    // with another collider with a health component
    public void OnTriggerEnter(Collider other)
    {
        // The health component of the other object is called
        Health otherHealth = other.gameObject.GetComponent<Health>();

         // Conditional statement to check if there is a health component
        if (otherHealth != null)
        {
            // Deals damage to the object that it collided with
            otherHealth.TakeDamage(damageDealt, owner);

        }
        // Destroys itself whether it did damage or not
        Destroy(gameObject);


    }
    

    

}
