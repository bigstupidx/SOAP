using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

    private UIManager ui_manager_script;            // Used to activate the game over screen
    public TailMovement tail_movement_script;       // Used to grow the avatars tail
    private SOAPStoreManager store_manager_script;  // Used to give player coins
    private Camera game_cam_ref;
	private CameraController challenge_room_camera;
    private SoundManager sound_manager_script;
    private GameObject player_death_particle_ref;
	private ParticleSystem player_death_particle;
	private Material player_death_mat;
	private Texture player_death_texture;

	// Use this for initialization
	void Start () 
    {
	    GameObject temp_1 = GameObject.Find("UI_canvas");
        if (temp_1 != null) { ui_manager_script = temp_1.GetComponent<UIManager>(); }

        GameObject temp_2 = GameObject.Find("store_ui_gr");
        if (temp_2 != null) { store_manager_script = temp_2.GetComponent<SOAPStoreManager>(); }

        GameObject temp_3 = GameObject.Find("audio_controller");
        if (temp_3 != null) { sound_manager_script = temp_3.GetComponent<SoundManager>(); }

		game_cam_ref = Camera.main;

		challenge_room_camera = game_cam_ref.GetComponent<CameraController>();
		player_death_particle_ref = GameObject.Find("player_death_particle");
		player_death_particle = player_death_particle_ref.gameObject.GetComponent<ParticleSystem>();
		player_death_mat = player_death_particle.GetComponent<ParticleSystemRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // When the play collides with anything that is a trigger....
	void OnCollisionEnter2D(Collision2D coll)
    {	
        // Obstacle collision: the player "dies", avatar setActive is set to false.
		if (coll.gameObject.tag == "obstacle" || coll.gameObject.tag == "tail")
        {
            // Disables the Collider2D component
            // TODO: Add animation or fx call here
			player_death();
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
        //Time.timeScale = 0;
		player_death();
        player_death_particle.gameObject.transform.position = this.gameObject.transform.position;
        player_death_particle.Play();
        Invoke("LoadGameOverDelayed", 1.5f);
        sound_manager_script.playSFX(SoundManager.CRASH_SFX);
    }


    // Turn the avatar game object off this will automatically trigger OnBecameInvisible()
    public void player_death()
    {
		player_death_texture = Resources.Load(PlayerPrefs.GetString("Avatar").ToString(), typeof(Texture2D)) as Texture;
		player_death_mat.mainTexture = player_death_texture;
		this.gameObject.SetActive(false);
    }


	public void LoadGameOverDelayed()
	{
		ui_manager_script.activate_game_over_menu();
	}
}
