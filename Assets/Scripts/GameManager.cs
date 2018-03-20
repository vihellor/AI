using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 


public class GameManager : MonoBehaviour
{

    public  GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
  

    //Awake is always called before any Start functions
    void Awake()
    {
        

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        boardScript.SetupScene();
    }



    //Update is called every frame.
    void Update()
    {

    }
}