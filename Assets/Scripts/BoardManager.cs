using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

    public class BoardManager : MonoBehaviour
    {
        public int columns = 15;                                         //Number of columns in our game board.
        public int rows = 15;                                            //Number of rows in our game board.
        public string fileNameToLoad;

        public int mapWidth;
        public int mapHeight;
        private int[,] tiles;
        public GameObject[] floorTiles, outerWallTiles; //Losetas
        private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object.

       
        public void SetupScene()
        {
            BoardSetup();
        }

    private int[,] Load(string filePath)
    {
        try
        {
            Debug.Log("Loading File...");
            using (StreamReader sr = new StreamReader(filePath))
            {
                string input = sr.ReadToEnd();
                string[] lines = input.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
                mapWidth = lines[0].Split(new[] { ',' }).Length;
                int[,] tiles = new int[lines.Length, mapWidth];
                Debug.Log("Parsing...");
                for (int i = 0; i < lines.Length; i++)
                {
                    string st = lines[i];
                    string[] nums = st.Split(new[] { ',' });
                    if (nums.Length != mapWidth)
                    {
                        Debug.Log("el tama�o no est� bien hay: " + nums.Length + " y el tama�o del mapa es: " + mapWidth);
                    }
                    for (int j = 0; j < Mathf.Min(nums.Length, mapWidth); j++)
                    {
                        int val;
                        if (int.TryParse(nums[j], out val))
                        {
                            tiles[i, j] = val;
                        }
                        else
                        {
                            tiles[i, j] = 1;
                        }
                    }
                }
                Debug.Log("Parsing Completed!");
                return tiles;
            }
        }
        catch (IOException e)
        {
            Debug.Log(e.Message);
        }
        return null;
    }

    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
        {
            //Instantiate Board and set boardHolder to its transform.
            boardHolder = new GameObject("Board").transform;
            tiles = Load(Application.dataPath + "\\" + "mapa.txt");
            //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
            for (int x = -1; x < columns + 1; x++)
            {
                //Loop along y axis, starting from -1 to place floor or outerwall tiles.
                for (int y = -1; y < rows + 1; y++)
                {
                    //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                    GameObject toInstantiate;
                    //Debug.Log(tiles[x,y]);    
                   
                    //Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
                    if (x == -1 || x == columns || y == -1 || y == rows)
                        toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                    else
                        toInstantiate = floorTiles[tiles[y,x]];
                    //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                    GameObject instance =
                        Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity) as GameObject;

                    //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                    instance.transform.SetParent(boardHolder);
                }
            }
        }
    }