using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

    private UIManager ui_manager_script;
    public TailMovement tail_movement_script;
    private Camera game_cam_ref;
	private CameraController challenge_room_camera;


	// Use this for initialization
	void Start () 
    {
	    GameObject temp_1 = GameObject.Find("UI");
        if (temp_1 != null) { ui_manager_script = temp_1.GetComponent<UIManager>(); }

		game_cam_ref = Camera.main;

		challenge_room_camera = game_cam_ref.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // When the play collides with anything that is a trigger....
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Obstacle collision: the player "dies", avatar setActive is set to false.
        if (coll.gameObject.tag == "obstacle")
        {
            // Disables the Collider2D component
            Debug.Log("This is the collider: " + coll.gameObject.name);
            // TODO: Add animation or fx call here
            this.gameObject.SetActive(false);
            ui_manager_script.activate_game_over_menu();
        }

        // Collect tails
        if (coll.gameObject.tag == "grow")
        {
            coll.gameObject.SetActive(false);
            tail_movement_script.grow_tail = true;
        }

        // Collect coins
        if (coll.gameObject.tag == "coin")
        {
            coll.gameObject.SetActive(false);
            // TODO: Add code to increase coins here
        }

        if (coll.gameObject.tag == "cam_hold_trigger")
        {
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
