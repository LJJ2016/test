using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{

    // Method 1
    Rigidbody2D rb;                     // Used to apply Physics and Collisions

    // Method 2
    public Rigidbody2D rb2;             // Used to apply Physics and Collisions

    // Varibles to help with Character jump
    public bool isGrounded;             // Used to tell if player is on Ground
    public LayerMask isGroundLayer;     // Used to tell what is ground
    public Transform groundCheck;       // Used to check collision with ground

    public bool onLadder;
    public LayerMask isLadderLayer;
    public Transform Laddercheck;

    public bool onFinishline;
    public LayerMask isFinishLayer;
    public Transform Finishcheck;




    public int curHealth;
    public int MaxHealth = 6;

    AudioSource audioSource;            
    public AudioClip sfxshoot;

    // Variables to control Animations
    Animator animController;

    // Use this for initialization
    void Start()
    {


        curHealth = MaxHealth;
        

        rb = GetComponent<Rigidbody2D>();

        if (!audioSource)
        {
            // Add an AudioSource component if it does not exist
            // - Can be used instead of RequireComponent
            audioSource = gameObject.AddComponent<AudioSource>();
        }


        // Check if Rigidbody2D is attached to GameObject
        if (!rb)
        {
            Debug.LogError("No Rigidbody2D attached, please attach a Rigidbody2D in Inspector.");
        }

        // Method 2
        // Check if Rigidbody2D is attached to GameObject
        if (!rb2)
        {
            Debug.LogError("No Rigidbody2D attached, please attach a Rigidbody2D in Inspector.");
        }

        // Gets reference to Animator when game starts
        animController = GetComponent<Animator>();

        // Check if Animator is attached to GameObject
        if (!animController)
        {
            Debug.LogError("No Animator attached, please attach a Animator in Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(curHealth > MaxHealth )
        {
            curHealth = MaxHealth;

        }


        if(curHealth <=0)
        {

            Die(); 

        }




        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, isGroundLayer);
        onLadder = Physics2D.OverlapCircle(Laddercheck.position, 0.2f, isLadderLayer);
        onFinishline  = Physics2D.OverlapCircle(Finishcheck.position, 0.2f, isFinishLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animController.SetTrigger("jump");

            Debug.Log("Jump was pressed.");


            rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);

           

        }


        if (Input.GetButtonDown("Fire1"))
        {
            animController.SetTrigger("Fire");

            Debug.Log("Pew pew.");

            audioSource.clip = sfxshoot;
            audioSource.Play();


        }


        float moveValue = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveValue, rb.velocity.y);


        animController.SetFloat("Move", Mathf.Abs(moveValue));

        if (onLadder)
        {
            float moveValue2 = Input.GetAxisRaw("Vertical");

            rb.velocity = new Vector3(moveValue, rb.velocity.x);

        }

        if(onFinishline)
        {

            Application.LoadLevel("Credits");


        }



    }



    void Die (){

Application.LoadLevel(Application.loadedLevel);

        

}

    public void Damage(int dmg)
    {
        curHealth -= dmg;


    }
}
    



