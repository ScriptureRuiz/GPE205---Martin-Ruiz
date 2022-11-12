using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    //holds the bullet Rigidbody
    private Rigidbody bulletRig;

    // this is a variable that holds the firePoint transform as a bullet spawning location
    public Transform firepointTransform;

    



    // Start is called before the first frame update
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {

    }


    public override void Shoot(GameObject bulletPrefab, float fireForce, float damageDealt, float bulletLifespan)
    {
     

            /*Instantiate is a copy of Prefab GameObjects and uses three parameters
           1. Prefab, 2.position. rotation
           The position and rotation will be the firepoint.*/
            GameObject newBullet = Instantiate(bulletPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;
           



            //attaches the newBullet RigidBody component to the "bulletRig" variable
            Rigidbody bulletRig = newBullet.GetComponent<Rigidbody>();


            // Checks if there is a Rigidbody
            if (bulletRig != null)
            {
                // Applies force to the newBullet Rigidbody using the Transform.forward command times the fireforce variable
                bulletRig.AddForce(firepointTransform.forward * fireForce);

                // Grabs the damagOnHit component from the bullet
                DamageOnHit damageComponent = newBullet.GetComponent<DamageOnHit>();

                if (damageComponent != null)
                {
                // applys the damage
                    damageComponent.damageDealt = damageDealt;
                    damageComponent.owner = GetComponent<MainPawn>();
                }

                // Destroy the bullet after the set lifespan
                Destroy(newBullet, bulletLifespan);

            }

    }


}
