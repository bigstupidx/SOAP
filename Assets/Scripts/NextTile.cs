using UnityEngine;
using System.Collections;

public class NextTile : MonoBehaviour 
{
	private GameObject tile_spawner_ref;

	private spawn_tiles spawn_tiles_script;

	// Use this for initialization
	void Start () 
	{
		tile_spawner_ref = GameObject.Find("Tile_Spawner");
		spawn_tiles_script =  tile_spawner_ref.GetComponent<spawn_tiles>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		// If the Collider2D component is enabled on the object we collided with
		if (coll.gameObject.tag == "Player")
		{
			spawn_tiles_script.move_tile();
		}
	}
}
