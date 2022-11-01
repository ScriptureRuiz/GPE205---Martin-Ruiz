using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform spawnTransform;
    private GameObject spawnedPickup;





    // Start is called before the first frame update
    void Start()
    {
        // Adds a delay before it spawns anything
        nextSpawnTime = Time.time + spawnDelay;
        spawnTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the pickup isnt there then spawn the pickup and restart the timer: else: delay the spawn
        if(spawnedPickup == null)
        {
            // Spawn if its time
            if (Time.time > nextSpawnTime)
            {
                // Spawn the prefab and start the clock for the next time
                spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
          else
        {
           //
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
