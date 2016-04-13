using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RegularTiles : MonoBehaviour 
{
	public GameObject[] spinning_obj_list;
	public GameObject[] moving_obj_listLR;
	public GameObject[] moving_obj_listUD;
	public GameObject[] falling_obj_list;
	public GameObject obstacle_manager_ref;
	private ObstacleManager obstacle_manager_script;
	private List<Vector3> falling_obj_position_list = new List<Vector3>();

	// Use this for initialization
	void Start () 
	{
		obstacle_manager_script = obstacle_manager_ref.GetComponent<ObstacleManager>();
		foreach(GameObject item in falling_obj_list)
		{
			falling_obj_position_list.Add(item.transform.position);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (spinning_obj_list.Length > 0)
		{	
			obstacle_manager_script.spinWalls();
		}

		if (moving_obj_listLR.Length > 0)
		{
			obstacle_manager_script.moveWallsLR();
		}

		if (moving_obj_listUD.Length > 0)
		{
			obstacle_manager_script.moveWallsUD();
		}

		if (moving_obj_listUD.Length > 0)
		{
			obstacle_manager_script.moveWallsUD();
		}

		if (falling_obj_list.Length > 0)
		{
			if (falling_obj_list[0].activeSelf == false)
			{
				for (int i = 0; i < falling_obj_list.Length; i++)
				{
					falling_obj_list[i].transform.position = falling_obj_position_list[i];
					falling_obj_list[i].GetComponent<Rigidbody2D>().isKinematic = true;
				}
			}

			else
			{
				obstacle_manager_script.dropBalls();
			}
		}
	}
}
