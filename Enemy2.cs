using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour
{

    // Used to spawn projectile at a location
    public Transform projectileSpawnPoint;

    // Used to create projectile prefab
    public Projectile projectile;

    // Used to fire Projectile in appropriate direction
    public bool isFacingRight;

    // Time based firing or Projectiles
    public float fireRate = 2.0f;
    float timeSinceLastFire = 0;

    // Use this for initialization
    void Start()
    {

        // Check if Transform is attached to GameObject
        if (!projectileSpawnPoint)
        {
            Debug.LogError("No projectileSpawnPoint attached, please attach a projectileSpawnPoint in Inspector.");
        }

        // Check if Projectile is attached to GameObject
        if (!projectile)
        {
            Debug.LogError("No Projectile attached, please attach a Projectile in Inspector.");
        }

        if (fireRate == 0)
            fireRate = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {

        // Check if enough time has passed since last projectile
        // was fired
        if (Time.time > timeSinceLastFire + fireRate)
        {
            // Create and fire Projectile
            fireProjectile();

            // Timestamp when Projectile was fired
            timeSinceLastFire = Time.time;
        }
    }

    // Function to fire a projectile
    void fireProjectile()
    {
        // Create a prefab at a location specified by the variable 
        // projectileSpawnPoint
        // - Needs prefab to fire (projectile)
        // - Needs location to fire from (projectileSpawnPoint.position)
        // - Needs rotation for projectile (projectileSpawnPoint.rotation)
        Projectile temp = Instantiate(projectile, projectileSpawnPoint.position,
            projectileSpawnPoint.rotation) as Projectile;

        if (isFacingRight)
            temp.speed = 5.0f;      // Assign a speed for Projectile object
        else
            temp.speed = -5.0f;     // Assign a left speed for Projectile object


        // Make projectile not hit Character
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(),
            temp.GetComponent<Collider2D>());

    } // Closes fireProjectile()
}
