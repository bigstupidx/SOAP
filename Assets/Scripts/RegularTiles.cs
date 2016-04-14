using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RegularTiles : MonoBehaviour 
{
	public GameObject obstacle_manager_ref;
	private ObstacleManager obstacle_manager_script;
	private List<Vector3> falling_obj_position_list = new List<Vector3>();

	// Use this for initialization
	void Start () 
	{
		obstacle_manager_script = obstacle_manager_ref.GetComponent<ObstacleManager>();
		foreach(GameObject item in obstacle_manager_script.falling_obstacles)
		{
			falling_obj_position_list.Add(item.transform.position);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (obstacle_manager_script.spinning_obstacles.Length > 0)
		{	
			obstacle_manager_script.spinWalls();
		}

		if (obstacle_manager_script.moving_wall_obstaclesLR.Length > 0)
		{
			obstacle_manager_script.moveWallsLR();
		}

		if (obstacle_manager_script.moving_wall_obstaclesUD.Length > 0)
		{
			obstacle_manager_script.moveWallsUD();
		}

		if (obstacle_manager_script.falling_obstacles.Length > 0)
		{
			if (obstacle_manager_script.falling_obstacles[0].activeSelf == false)
			{
				for (int i = 0; i < obstacle_manager_script.falling_obstacles.Length; i++)
				{
					obstacle_manager_script.falling_obstacles[i].transform.position = falling_obj_position_list[i];
					obstacle_manager_script.falling_obstacles[i].GetComponent<Rigidbody2D>().isKinematic = true;
				}
			}

			else
			{
				obstacle_manager_script.dropBalls();
			}
		}
	}
}
