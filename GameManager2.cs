using UnityEngine;
using System.Collections;

public class GameManager2 : MonoBehaviour {

    static GameManager2 _instance = null;

    // Create references to the canvas' in Scene
    public Canvas canvasTitle;
    public Canvas canvasHUD;

    // Used to create player when game or level starts
    public GameObject playerPrefab;

    // Use this for initialization
    void Start()
    {

        // Show appropriate canvas in Scene
        canvasTitle.enabled = true;
        canvasHUD.enabled = false;

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
            if (Application.loadedLevelName == "Scene_Stageselect")
            {
                // Switch to Level1 Scene
                //SceneManager.LoadScene("Level1"); // New Version
                Application.LoadLevel("Level1");    // Soon to be Obsolete Version

                // Show appropriate canvas in Scene
                canvasTitle.enabled = false;
                canvasHUD.enabled = true;
            }
            // Check if game is in Level1 Scene
            else if (Application.loadedLevelName == "Level1")
            {
                // Switch to Scene_Title Scene
                //SceneManager.LoadScene("Scene_Title"); // New Version
                Application.LoadLevel("Scene_Stageselect");    // Soon to be Obsolete Version

                // Show appropriate canvas in Scene
                canvasTitle.enabled = true;
                canvasHUD.enabled = false;
            }
        }
    }

    // Used to start game
    // - Linked to Start button on Canvas
    public void StartGame()
    {
        //SceneManager.LoadScene("Level1"); // New Version
        Application.LoadLevel("Level1");    // Soon to be Obsolete Version

        // Show appropriate canvas in Scene
        canvasTitle.enabled = false;
        canvasHUD.enabled = true;
    }

    // Used to Spawn Player at appropriate position in Scene
    public void SpawnPlayer(int levelLocation)
    {
        // Create string to search for in Scene
        // Level1_1 where levelLocation is passed to function
        string spawnPoint = Application.loadedLevelName + "_" + levelLocation;

        // Actual location can be found
        Transform spawnPointTransform = GameObject.Find(spawnPoint).GetComponent<Transform>();

        // Create Player in Scene and location found
        // - Can be different for every level
        Instantiate(playerPrefab, spawnPointTransform.position, spawnPointTransform.rotation);
    }

    // Gives access to private data
    // Not needed if using public data
    // - Public is considered bad because it can be changed anywhere and nothing knows it is getting changed
    // - These force the user to use the functions to change things. 
    // - Can be used to make sure things are valid before applying them.
    public static GameManager2 instance    // GameManager instance matches variable declaration except for the '_' before the name
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
