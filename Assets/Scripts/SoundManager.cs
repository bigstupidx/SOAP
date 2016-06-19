using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    //public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             

    // NOTE: To have more than one audio clip playing back at the same time
    //       there needs to be more than one audio source 

    public AudioClip[] sfx_clips;       // Array of sound effect audio clips
    public GameObject start_mute_btn;
    public GameObject start_unmute_btn;
    public GameObject go_mute_btn;
    public GameObject go_unmute_btn;

    private AudioSource sfx_source;     // The audio source that play the audio clips

    public const int COIN_SFX = 0;      // Index position of coin sfx in sfx_clips array
    public const int TAIL_SFX = 1;      // Index position of tail grow sfx in sfx_clips array
    public const int CRASH_SFX = 2;     // Index position of avatar crash sfx in sfx_clips array

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        //if (instance == null)
        //    //if not, set it to this.
        //    instance = this;
        ////If instance already exists:
        //else if (instance != this)
        //    //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
        //    Destroy(gameObject);

        ////Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);

        sfx_source = this.GetComponent<AudioSource>();
    }


    // Play the SFX audio
    public void playSFX(int index)
    {
        sfx_source.PlayOneShot(sfx_clips[index]);
    }


    // Turn on/off audio playback and display correct button
    public void setMuteState()
    {
        sfx_source.enabled = !sfx_source.enabled;

        bool btn_state = sfx_source.enabled;

        start_mute_btn.SetActive(btn_state);
        go_mute_btn.SetActive(btn_state);
        start_unmute_btn.SetActive(!btn_state);
        go_unmute_btn.SetActive(!btn_state);
    }

}