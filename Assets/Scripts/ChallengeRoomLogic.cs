using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChallengeRoomLogic : MonoBehaviour 
{

	public GameObject challenge_tile_ref;

	public GameObject[] grow_obj_list;

	public GameObject cam_hold_ref;
	public GameObject cam_release_ref;

	public GameObject top_door_ref;
	public GameObject bottom_door_ref;

	private int grow_counter = 0;

	private Camera game_cam_ref;
	private CameraController challenge_room_camera;

	// Use this for initialization
	void Start () 
	{
		game_cam_ref = Camera.main;
		challenge_room_camera = game_cam_ref.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (grow_counter > grow_obj_list.Length )
		{
			challenge_room_camera.release_camera();
			hide_challenge_doors();
		}
	}

	public void show_grow_objects()
	{
		if (grow_counter < grow_obj_list.Length)
		{
			grow_obj_list[grow_counter].SetActive(true);
		}

		grow_counter++;
	}

	public void show_challenge_doors()
	{
		top_door_ref.SetActive(true);
		bottom_door_ref.SetActive(true);	
	}

	public void hide_challenge_doors()
	{
		top_door_ref.SetActive(false);
		bottom_door_ref.SetActive(false);	
	}
}
