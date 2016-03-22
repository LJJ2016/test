using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float speed;
    public bool isFacingRight;
    public Transform respawnLocation;
    Rigidbody2D rb;
    Animator animController;

    private movement player;

    // Use this for initialization
    void Start()
    {
        animController = GetComponent<Animator>();
        // Initialize all variables and Components
        if (speed == 0)
            speed = 0.3f;

        // Keep reference to Rigidbody2D Component
        rb = GetComponent<Rigidbody2D>();

        // Check if there is a Rigidbody2D attached
        if (!rb)
        {
            // Adds Rigidbody2D Component to GameObject
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        if (!isFacingRight)
            speed *= -1;
    }


    void OnTriggerEnter2D(Collider2D c)
    {
        
            if (c.CompareTag("Player"))
            {
                player.Damage(1);
            }
        
    }








    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    // Function called when Enemy collides with something
    void OnCollisionEnter2D(Collision2D c)
    {
        // Using tags
        //if(c.gameObject.tag == "Groud")

        // Using layers
        if (c.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            // Flip Enemy
            flip();

            // Change speed
            speed *= -1;
        }


        float moveValue = speed;
        animController.SetFloat("Move", Mathf.Abs(moveValue));



    }

   


    // Used to make Character face direction Character is moving
    void flip()
    {
        // Method 1: Toggle Variable for direction
        isFacingRight = !isFacingRight;

        // Method 2: Toggle Variable for direction
        /*if (isFacingRight)
            isFacingRight = false;
        else if (!isFacingRight)
            isFacingRight = true;
        */

        // Make a copy of currrent Character scale
        Vector3 scaleFactor = transform.localScale;

        // Flip horizontal scale
        scaleFactor.x *= -1; // Changes scale to (-1,1,1)

        // Update scale of Character
        transform.localScale = scaleFactor;
    }
}