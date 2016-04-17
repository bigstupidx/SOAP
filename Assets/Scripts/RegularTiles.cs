using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RegularTiles : MonoBehaviour 
{
	//public GameObject obstacle_manager_ref;
	private ObstacleManager obstacle_manager_script;
	private List<Vector3> falling_obj_position_list = new List<Vector3>();

	private GameObject tile_spawner_ref;
	private spawn_tiles spawn_tiles_script;

	// Use this for initialization
	void Start () 
	{
		obstacle_manager_script = this.GetComponent<ObstacleManager>();
		foreach(GameObject item in obstacle_manager_script.falling_obstacles)
		{
			falling_obj_position_list.Add(item.transform.position);
		}

		tile_spawner_ref = GameObject.Find("Tile_Spawner");
		spawn_tiles_script = tile_spawner_ref.GetComponent<spawn_tiles>();
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

			if (spawn_tiles_script.tile_list[3].name == this.gameObject.name)
			{	
				if(spawn_tiles_script.IsFirst == false)
				{
					for (int i = 0; i < obstacle_manager_script.falling_obstacles.Length; i++)
					{
						obstacle_manager_script.falling_obstacles[i].gameObject.transform.position = falling_obj_position_list[i];
						obstacle_manager_script.falling_obstacles[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
					}
				}

				else
				{
					obstacle_manager_script.dropBalls();
				}
			}

			else
			{
				obstacle_manager_script.dropBalls();
			}
		}
	}
}
