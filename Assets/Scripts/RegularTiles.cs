using UnityEngine;
using System.Collections;

public class RegularTiles : MonoBehaviour 
{
	public GameObject[] spinning_obj_list;
	public GameObject[] moving_obj_list;

	public GameObject obstacle_manager_ref;
	private ObstacleManager obstacle_manager_script;

	// Use this for initialization
	void Start () 
	{
		obstacle_manager_script = obstacle_manager_ref.GetComponent<ObstacleManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (spinning_obj_list.Length > 0)
		{	
			obstacle_manager_script.spinWalls();
		}

		if (moving_obj_list.Length > 0)
		{
			obstacle_manager_script.moveWalls();
		}
	}
}
