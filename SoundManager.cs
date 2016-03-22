using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    static SoundManager _instance = null;
    AudioSource sfxSource;

    // Use this for initialization
    void Start()
    {

        sfxSource = GetComponent<AudioSource>();

        if (!sfxSource)
        {
            Debug.Log("No AudioSource attached to GameObject.");
            sfxSource = gameObject.AddComponent<AudioSource>(); // or do a RequireComponent at the top
        }

        // Check if instance of SoundManager already exists
        if (instance)
        {
            // Destroy SoundManager if it already exists
            DestroyImmediate(gameObject);
        }
        else
        {
            // SoundManager does not exist, keep a reference to it
            instance = this;
            // Make sure it doesnt get destroyed when switching Scenes
            DontDestroyOnLoad(this);
        }
    }

    // Public function that will be called when a sound needs to be played
    public void PlaySFX(AudioClip clip)
    {
        // Assign AudioClip to play through AudioSource
        sfxSource.clip = clip;

        // Play sound clip
        sfxSource.Play();
    }

    // Gives access to private data
    // Not needed if using public data
    // - Public is considered bad because it can be changed anywhere and nothing knows it is getting changed
    // - These force the user to use the functions to change things. 
    // - Can be used to make sure things are valid before applying them.
    public static SoundManager instance    // SoundManager instance matches variable declaration except for the '_' before the name
    {
        get
        {
            return _instance;   // Return private variables value
        }

        set
        {
            _instance = value; // Assign copy of SoundManager to _instance
        }
    }
}
