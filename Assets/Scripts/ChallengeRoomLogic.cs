using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChallengeRoomLogic : MonoBehaviour 
{
	public GameObject[] grow_obj_list;
	public GameObject cam_hold_ref;
	public GameObject top_door_ref;
	public GameObject bottom_door_ref;
    public GameObject reset_trigger;

	private int grow_counter = 0;
    private int total_tails_collected = 0;      // Number of tails collected throughout the entire game
	private Camera game_cam_ref;
	private CameraController challenge_room_camera;
    private bool show_grow_counter = false;
    private Text grow_counter_text;
    private TailMovement tail_movement_script;

	// Use this for initialization
	void Start () 
	{
		game_cam_ref = Camera.main;
		challenge_room_camera = game_cam_ref.GetComponent<CameraController>();

        // If start tile then show the tail collection text display
        if (this.gameObject.tag == "start_tile")
        {
            show_grow_counter = true;
            GameObject temp_1 = GameObject.Find("game_screen_grow_counter_txt");
            if (temp_1 != null) { grow_counter_text = temp_1.GetComponent<Text>(); }
            grow_counter_text.text = string.Format("{0}/{1}", grow_counter, grow_obj_list.Length);
        }

        // If first tile is not start tile then start with tails
        else
        {
            grow_counter_text.gameObject.SetActive(false);

            GameObject temp_2 = GameObject.Find("tail_movement_script");
            if (temp_2 != null) { tail_movement_script = temp_2.GetComponent<TailMovement>(); }
            tail_movement_script.startWithTails();
        }
	}


    // Show the first tail when the cam trigger hold game object is enetered (CollisionManager)
    public void showFirstTail()
    {
        grow_obj_list[0].SetActive(true);
    }


    // Re-active the cam hold trigger game object when the challenge room is exited
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.name == reset_trigger.name)
        {
            cam_hold_ref.SetActive(true);
        }
    }


    // Show the next grow object, reset when all collected
	public void show_grow_objects()
	{
        grow_counter++;
        total_tails_collected++;

        // Update the tail counter collection ui each time a tail is collected
        if (show_grow_counter)
        {
            grow_counter_text.text = string.Format("{0}/{1}", grow_counter, grow_obj_list.Length);
        }

        // Check for achievement qualifications met
        checkAchievements();

        // Show next grow object
		if (grow_counter < grow_obj_list.Length)
		{
			grow_obj_list[grow_counter].SetActive(true);
		}

        // Open challenge room doors 
        else
        {
            challenge_room_camera.release_camera();
            hide_challenge_doors();
            grow_counter = 0;

            // Set the tail counter game object to false when all tails collected
            if (this.gameObject.tag == "start_tile")
            {
                grow_counter_text.gameObject.SetActive(false);
            }
        }
	}


    // Check if user has collected enough tails to earn an achievment
    public void checkAchievements()
    {
        string num_tails = total_tails_collected.ToString();

        // Unlock achievement for collecting specific number of tails
        switch (num_tails)
        {
            case "9":
                Achievements.pythonAchievement();
                break;
            case "15":
                Achievements.anacondaAchievement();
                break;
            case "21":
                Achievements.titanoboaAchievement();
                break;
        }
    }


	public void show_challenge_doors()
	{
		top_door_ref.gameObject.SetActive(true);
		bottom_door_ref.gameObject.SetActive(true);	
	}


	public void hide_challenge_doors()
	{
		top_door_ref.gameObject.SetActive(false);
		bottom_door_ref.gameObject.SetActive(false);	
	}
}
