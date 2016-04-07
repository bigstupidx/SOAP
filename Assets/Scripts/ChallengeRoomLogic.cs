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

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(cam_hold_ref.gameObject.activeSelf == false)
		{
			Debug.Log("The game object is: " + cam_hold_ref.gameObject.activeSelf);
			foreach(GameObject item in grow_obj_list)
			{
				item.gameObject.SetActive(true);
			}
		}
	}
}
