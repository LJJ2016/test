using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    // Length of time projectile exists
    public float lifeTime;
    public float speed;

    // Use this for initialization
    void Start()
    {

        // Check that lifeTime is not 0 or a negative value
        if (lifeTime <= 0)
        {
            // Sets a default time if one is not entered
            lifeTime = 0.2f;
        }

        // Destroy projectile GameObject if it doesnt collide with anything
        Destroy(gameObject, lifeTime);

        // Destroy(this, lifeTime); // Only destroys Script not gameObject

        // Make projectile move when instantiated
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
