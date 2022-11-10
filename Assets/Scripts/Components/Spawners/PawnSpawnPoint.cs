using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PawnSpawnPoint : MonoBehaviour
{
    public GameObject enemySpawn;

    public GameObject playerSpawn;

    // Start is called before the first frame update
    void Start()
    {


        if (GameManager.instance != null)
        {
            // if the Gamemanager tracks an instance of the spawn points
            if (GameManager.instance.allSpawns != null)
            {
                // Register an instance of the spawns with the gamemanager (add (this))
                GameManager.instance.allSpawns.Add(this);
            }
        }





    }
        // Update is called once per frame
        void Update()
        {

        }












    public void OnDestroy()
    {// Checkes for GameManager
        if (GameManager.instance != null)
        {//Checks for spawns list
            if (GameManager.instance.allSpawns != null)
            {// Removes it from the list
                GameManager.instance.allSpawns.Remove(this);
            }
        }
    }
}


