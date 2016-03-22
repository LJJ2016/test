using UnityEngine;
using System.Collections;

public class GameManger3 : MonoBehaviour {


    // Create a variable to keep track of GameManager instance
    // - Only once instance should be created
    // - _instance is used with Get and Set function below
    static GameManger3 _instance = null;

    // Create references to the canvas' in Scene
    public Canvas Canvas_credits;
    
    
   

    // Use this for initialization
    void Start()
    {

        // Show appropriate canvas in Scene
        Canvas_credits.enabled = true;
        

        // Check if instance of GameManager already exists
        if (instance)
        {
            // Destroy GameManger if it already exists
            DestroyImmediate(gameObject);
        }
        else
        {
            // GameManager does not exist, keep a reference to it
            instance = this;
            // Make sure it doesnt get destroyed when switching Scenes
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if game is in Scene_Title Scene
            if (Application.loadedLevelName == "Credits")
            {
                // Switch to Level1 Scene
                //SceneManager.LoadScene("Level1"); // New Version
                Application.LoadLevel("Scene_Title");    // Soon to be Obsolete Version

                // Show appropriate canvas in Scene
                Canvas_credits.enabled = false;
                
            }
            // Check if game is in Level1 Scene
            else if (Application.loadedLevelName == "Credits")
            {
                // Switch to Scene_Title Scene
                //SceneManager.LoadScene("Scene_Title"); // New Version
                Application.LoadLevel("Scene_Title");    // Soon to be Obsolete Version

                // Show appropriate canvas in Scene
                Canvas_credits.enabled = true;
               
            }
           

        }
    }

    // Used to start game
    // - Linked to Start button on Canvas
    public void StartGame()
    {
        //SceneManager.LoadScene("Level1"); // New Version
        Application.LoadLevel("Scene_Title");    // Soon to be Obsolete Version

        // Show appropriate canvas in Scene
        Canvas_credits.enabled = false;
        
    }

    
    public static GameManger3 instance    // GameManager instance matches variable declaration except for the '_' before the name
    {
        get
        {
            return _instance;   // Return private variables value
        }

        set
        {
            _instance = value; // Assign copy of GameManager to _instance
        }
    }
}