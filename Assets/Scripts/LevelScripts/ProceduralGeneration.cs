using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class ProceduralGeneration : MonoBehaviour
{
    public int mapSeed;


    
    // An array that holds our rooms

    public GameObject[] roomGridPrefabs;
    public int rows;
    public int columns;
    private float roomWidth=50.0f;
    private float roomHeight = 50.0f;
    private Room[,] roomGrid;

    
   
// Start is called before the first frame update
    public void Start()
    {


        if (MapOfTheDay())
        {
            mapSeed = DateToInt(DateTime.Now.Date);
        }

        GenerateMap();
        

    }

    // Update is called once per frame
    void Update()
    {
        


    }


   
        // This function returns a random room
        public GameObject RandomRoomPrefab()
    {
        return roomGridPrefabs[UnityEngine.Random.Range(0, roomGridPrefabs.Length)];
    }



    public void GenerateMap()
    {
        //grid is cleared out and column is x and rows are z
        roomGrid = new Room[columns, rows];
        
        // Random seed for generating maps 
        UnityEngine.Random.seed = DateToInt(DateTime.Now);

        UnityEngine.Random.seed = mapSeed;
       

        //for each grid row "Z"
        for (int currentRow = 0; currentRow < rows;++currentRow) 
        {
          

            // for each column in that row "x"
            for (int currentCol = 0; currentCol < columns; ++currentCol)
            {

                //find the location
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);
               
                
                // Create a new grid on location
                GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;


                //Set its parent
                tempRoomObj.transform.parent=this.transform;

                // Gives it a new name according to the coordinates
                    tempRoomObj.name="Room_"+currentCol+","+currentRow;

                //Grabs the room component
                    Room tempRoom = tempRoomObj.GetComponent<Room>();

                   
                //  Open the north and south doors
                if (currentRow == 0)
                {
                   tempRoom.doorNorth.SetActive(false);
                    
                }
                else if (currentRow==rows-1)
                {
                    Destroy(tempRoom.doorSouth);
                    
                }
                else
                {
                    
                        Destroy(tempRoom.doorNorth);
                        Destroy(tempRoom.doorSouth);
                            
                }

                // Open East and West
                if (currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == columns -1)
                {
                    Destroy(tempRoom.doorWest);
                }
                else
                {
                    Destroy(tempRoom.doorWest);
                    Destroy(tempRoom.doorEast);
                }
                    


                // Saves it to the roomGrid
                roomGrid[currentCol,currentRow]=tempRoom;

                
                


            }

           
        }


        

    }

    public int DateToInt(DateTime dateToUse)
    {
        // Add our date up and returns it as a whole integer jan,1,2022 = 2024...2022+1+1
        return dateToUse.Year+dateToUse.Month+dateToUse.Day +dateToUse.Hour+dateToUse.Minute+dateToUse.Second+dateToUse.Millisecond;

    }
    
    public  bool MapOfTheDay()
    {
        if (mapSeed==0)
        {
            return true; 
        }
        else
        {
            return false;
        }
    }


    
   


}
