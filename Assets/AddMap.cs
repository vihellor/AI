using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public class Add : MonoBehaviour {
    public string fileNameToLoad;

    public int mapWidth;
    public int mapHeight;

    public GameObject Floor;
    public GameObject Bricks;
    public GameObject Wall;
    public GameObject WallWithTorch;
    public GameObject Roof;

    private int[,] tiles;

    void BuildMap()
    {
        Debug.Log("Building Map...");
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                if (tiles[i, j] == 0)
                {
                    print("en "+i+","+j+"0");
                    //GameObject TilePrefab  = Instantiate(Bricks, new Vector3(j - mapWidth, mapHeight - i, 1), Quaternion.identity) as GameObject;
                    //TilePrefab.transform.parent = GameObject.FindGameObjectWithTag("Room").transform;
                }
                else
                if (tiles[i, j] == 1)
                {
                    print("en " + i + "," + j + "1");
                    //GameObject TilePrefab  = Instantiate(Bricks, new Vector3(j - mapWidth, mapHeight - i, 1), Quaternion.identity) as GameObject;
                    //TilePrefab.transform.parent = GameObject.FindGameObjectWithTag("Room").transform;
                }
                else
                if (tiles[i, j] == 2)
                {
                    print("en " + i + "," + j + "2");
                    //GameObject TilePrefab = TilePrefab = Instantiate(Roof, new Vector3(j - mapWidth, mapHeight - i, 0), Quaternion.identity) as GameObject;
                    //TilePrefab.transform.parent = GameObject.FindGameObjectWithTag("Room").transform;

                }
                else
                if (tiles[i, j] == 3)
                {
                    print("en " + i + "," + j + "3");
                    //GameObject TilePrefab = TilePrefab = Instantiate(Wall, new Vector3(j - mapWidth, mapHeight - i, 0), Quaternion.identity) as GameObject;
                    //TilePrefab.transform.parent = GameObject.FindGameObjectWithTag("Room").transform;

                }
                else
                if (tiles[i, j] == 4)
                {
                    print("en " + i + "," + j + "4");
                    //GameObject TilePrefab = TilePrefab = Instantiate(Floor, new Vector3(j - mapWidth, mapHeight - i, 1), Quaternion.identity) as GameObject;
                    //TilePrefab.transform.parent = GameObject.FindGameObjectWithTag("Room").transform;
                }
                else
                if (tiles[i, j] == 5)
                {
                    print("en " + i + "," + j + "5");
                    //GameObject TilePrefab = TilePrefab = Instantiate(WallWithTorch, new Vector3(j - mapWidth, mapHeight - i, 0), Quaternion.identity) as GameObject;
                    //TilePrefab.transform.parent = GameObject.FindGameObjectWithTag("Room").transform;
                }
            }
        }
        Debug.Log("Building Completed!");
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
                int[,] tiles = new int[lines.Length, mapWidth];
                Debug.Log("Parsing...");
                for (int i = 0; i < lines.Length; i++)
                {
                    string st = lines[i];
                    string[] nums = st.Split(new[] { ',' });
                    if (nums.Length != mapWidth)
                    {

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
    // Use this for initialization
    void Start () {
        Debug.Log("voy a intentar cargar el archivo");
        tiles = Load(Application.dataPath + "\\" + "mapa.txt");
        Debug.Log("ahora a intentar ver qué hay por aquí");
        BuildMap();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
