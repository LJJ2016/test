using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement; // Must be added to use SceneManager class

public class GameManager : MonoBehaviour
{

    // Create a variable to keep track of GameManager instance
    // - Only once instance should be created
    // - _instance is used with Get and Set function below
    static GameManager _instance = null;

    // Create references to the canvas' in Scene
    public Canvas canvasTitle;
    
    
   

    // Use this for initialization
    void Start()
    {

        // Show appropriate canvas in Scene
        canvasTitle.enabled = true;
        

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
            if (Application.loadedLevelName == "Scene_Title")
            {
                // Switch to Level1 Scene
                //SceneManager.LoadScene("Level1"); // New Version
                Application.LoadLevel("Scene_Stageselect");    // Soon to be Obsolete Version

                // Show appropriate canvas in Scene
                canvasTitle.enabled = false;
                
            }
            // Check if game is in Level1 Scene
            else if (Application.loadedLevelName == "Scene_Stageselect")
            {
                // Switch to Scene_Title Scene
                //SceneManager.LoadScene("Scene_Title"); // New Version
                Application.LoadLevel("Scene_Title");    // Soon to be Obsolete Version

                // Show appropriate canvas in Scene
                canvasTitle.enabled = true;
               
            }
           

        }
    }

    // Used to start game
    // - Linked to Start button on Canvas
    public void StartGame()
    {
        //SceneManager.LoadScene("Level1"); // New Version
        Application.LoadLevel("Scene_Stageselect");    // Soon to be Obsolete Version

        // Show appropriate canvas in Scene
        canvasTitle.enabled = false;
        
    }

    
    public static GameManager instance    // GameManager instance matches variable declaration except for the '_' before the name
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
