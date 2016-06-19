using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

    private UIManager ui_manager_script;            // Used to activate the game over screen
    public TailMovement tail_movement_script;       // Used to grow the avatars tail
    private SOAPStoreManager store_manager_script;  // Used to give player coins
    private Camera game_cam_ref;
	private CameraController challenge_room_camera;
    private SoundManager sound_manager_script;


	// Use this for initialization
	void Start () 
    {
	    GameObject temp_1 = GameObject.Find("UI");
        if (temp_1 != null) { ui_manager_script = temp_1.GetComponent<UIManager>(); }

        GameObject temp_2 = GameObject.Find("store_ui_gr");
        if (temp_2 != null) { store_manager_script = temp_2.GetComponent<SOAPStoreManager>(); }

        GameObject temp_3 = GameObject.Find("audio_controller");
        if (temp_3 != null) { sound_manager_script = temp_3.GetComponent<SoundManager>(); }

		game_cam_ref = Camera.main;

		challenge_room_camera = game_cam_ref.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // When the play collides with anything that is a trigger....
	void OnCollisionEnter2D(Collision2D coll)
    {	
        // Obstacle collision: the player "dies", avatar setActive is set to false.
        if (coll.gameObject.tag == "obstacle")
        {
            // Disables the Collider2D component
            Debug.Log("This is the collider: " + coll.gameObject.name);
            // TODO: Add animation or fx call here
            this.gameObject.SetActive(false);
            ui_manager_script.activate_game_over_menu();

            sound_manager_script.playSFX(SoundManager.CRASH_SFX);
        }

		//if (coll.gameObject.tag == "cam_release_trigger")
        //{
			//challenge_room_camera.release_camera();
        //}

    }


    // Collect coins and grow tails
    void OnTriggerEnter2D(Collider2D other)
    {
        // Collect coins
        if (other.gameObject.tag == "coin")
        {
            other.gameObject.SetActive(false);
            store_manager_script.giveCoins();
            sound_manager_script.playSFX(SoundManager.COIN_SFX);
        }


        // Collect tails
        if (other.gameObject.tag == "grow")
        {
            other.transform.parent.parent.GetComponent<ChallengeRoomLogic>().show_grow_objects();
            other.gameObject.SetActive(false);
            tail_movement_script.grow_tail = true;

            sound_manager_script.playSFX(SoundManager.TAIL_SFX);
        }

        if (other.gameObject.tag == "challenge_gate")
        {
			other.gameObject.SetActive(false);
			store_manager_script.challengeCoins();
			sound_manager_script.playSFX(SoundManager.COIN_SFX);
        }

		if (other.gameObject.tag == "cam_hold_trigger")
        {
			other.transform.parent.parent.GetComponent<ChallengeRoomLogic>().show_grow_objects();
			other.transform.parent.parent.GetComponent<ChallengeRoomLogic>().show_challenge_doors();
			other.gameObject.SetActive(false);
			challenge_room_camera.hold_camera();
        }

    }


    // When the avatar is out of the camera's view end the game
    void OnBecameInvisible()
    {
        // TODO: Add animation or fx call here
        Time.timeScale = 0;
        ui_manager_script.activate_game_over_menu();
    }
}
