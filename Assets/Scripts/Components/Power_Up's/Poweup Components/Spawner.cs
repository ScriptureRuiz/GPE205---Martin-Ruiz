using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;






    // Start is called before the first frame update
    void Start()
    {
        // Adds a delay before it spawns anything
        nextSpawnTime = Time.time + spawnDelay;
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // If enough time has passed to spawn a pickup
        if (Time.time>nextSpawnTime)
        {
            // Spawns the prefab at the transform position
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
            // sets the next time it can spawn
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
