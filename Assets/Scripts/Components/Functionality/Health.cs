using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // These variables hold the health value of any object that its attached to
    public float currentHealth;
    public float maxHealth;

    // Start is called before the first frame update
     void Start()
    {
        // Start with max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
     void Update()
    {
        
    
    }

    // This function deals with the "amount" of damage taken and the source of that damage
    public void TakeDamage(float damageDealt, MainPawn source)
    {
        // The damage taken
        currentHealth = currentHealth - damageDealt;
        // A message for testing puposes that tells who shot who and done what damage
        Debug.Log(source.name + "did" + damageDealt + "damage to"+gameObject.name);
         /* This is a clamp that keeps the currenHealth from going out of range when taking damage
          *The first parameter is the target Health, the second is the lowest value in range , and
          *the third is the highest value in range*/
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        /*A conditional statement to check if the current health
        is zero or less, then it runs the Die() functiond*/
        if (currentHealth<=0)
        {
            Die(source);
        }

    }
    // this function handles the death of the object
    public void Die(MainPawn source)
    {
        Destroy(gameObject);
    }

    // This function handles healing
    public void Heal(float healingGained,MainPawn source)
    {
        currentHealth = currentHealth + healingGained;
        Debug.Log(gameObject.name + "Healed" + healingGained);

      // A clamp to limit the range of healing to the max value
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);


    }

}
