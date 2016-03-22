using UnityEngine;
using System.Collections;

public class GameManager4 : MonoBehaviour {

    public int numberOfCollectibles;        // Used to keep track of how many collectibles are left
    public GameObject[] allCollectibles;    // Used to keep track of collectible GameObjects left

    public GameObject finishLine;           // Used to keep track of end of level
    public GameObject player;               // Used to reference player to check for distance remaining in the level

    // Use this for initialization
    void Start()
    {
        // Find functions only find things that are activated in the Scene and must exist in the Scene
        // - They should only be called in Awake() or Start()

        // Finds all GameObjects tagged as Collectible and stores them in an array for use later on
        allCollectibles = GameObject.FindGameObjectsWithTag("Collectibles");

        // Finds all GameObjects tagged as Collectible and stores the number of instances in the Scene
        numberOfCollectibles = GameObject.FindGameObjectsWithTag("Collectibles").Length;

       
        // Method 2: Looks through entire Scene to find GameObject tagged as Player in Scene
        player = GameObject.FindGameObjectWithTag("Player");

        // Method 1: Looks through entire Scene to find GameObject named FinishLine in Scene
        finishLine = GameObject.Find("FinishLine");
    }

    // Update is called once per frame
    void Update()
    {

        // Check if player and FinishLine were found in the Scene
        if (player && finishLine)
        {
            // Calculate distance between the two GameObjects
            float distanceToFinish = Vector2.Distance(player.transform.position,
                finishLine.transform.position);

            // Print distance to Console. No UI yet.
            //Debug.Log("Distance Remaining: " + distanceToFinish);
        }
    }
}