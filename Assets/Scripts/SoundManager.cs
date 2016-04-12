using UnityEngine;
using System.Collections;


public class SoundManager : MonoBehaviour
{
    //public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             

    // NOTE: To have more than one audio clip playing back at the same time
    //       there needs to be more than one audio source 

    public AudioClip[] sfx_clips;       // Array of sound effect audio clips
    private AudioSource sfx_source;     // The audio source that play the audio clips

    public const int COIN_SFX = 0;      // Index position of coin sfx in sfx_clips array
    public const int TAIL_SFX = 1;      // Index position of tail grow sfx in sfx_clips array
    public const int CRASH_SFX = 2;     // Index position of avatar crash sfx in sfx_clips array

    void Awake()
    {
        ////Check if there is already an instance of SoundManager
        //if (instance == null)
        //    //if not, set it to this.
        //    instance = this;
        ////If instance already exists:
        //else if (instance != this)
        //    //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
        //    Destroy(gameObject);

        ////Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        //DontDestroyOnLoad(gameObject);

        sfx_source = this.GetComponent<AudioSource>();
    }


    public void playSFX(int index)
    {
        sfx_source.PlayOneShot(sfx_clips[index]);
    }
}