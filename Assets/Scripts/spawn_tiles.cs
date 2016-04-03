using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawn_tiles : MonoBehaviour 
{
	public GameObject[] tile_prefabs;
	private int starting_tiles;
	private int initial_tiles = 4;
	private int next_tile = 0;
	List<GameObject> tile_list = new List<GameObject>();
	private Vector3 previous_tile_size;
	private BoxCollider2D tile_collider;
	
	// Use this for initialization
	void Start () 
	{
		tile_list.Clear();
		for(int i = 0; i < initial_tiles;)
		{
			starting_tiles = Random.Range(0, tile_prefabs.Length);

			if(tile_list.Contains(tile_prefabs[starting_tiles]))
			{
				//Debug.Log("The GameObject is: " + tile_prefabs[starting_tiles]);
			}
			
			else
			{
				tile_list.Add(tile_prefabs[starting_tiles]);
				tile_list[i].SetActive(true);
				
				if (i >= 1)
				{
					previous_tile_size = tile_list[i-1].GetComponent<SpriteRenderer>().bounds.size;
					tile_list[i].transform.position = new Vector3(0, tile_list[i-1].transform.position.y + previous_tile_size.y, 0);
				}
				
				i++;
			}
		}
		
		tile_list.Reverse();
		tile_collider = tile_list[3].GetComponent<BoxCollider2D>();
		tile_collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	public void add_next_tile()
	{
		tile_list[3].SetActive(false);
		tile_list.RemoveAt(3);
		
		for(int i = 0; i < 1;)
		{
			next_tile = Random.Range(0, tile_prefabs.Length);
		
			if(tile_list.Contains(tile_prefabs[next_tile]))
			{
				//Debug.Log("The GameObject is: " + tile_prefabs[starting_tiles]);
			}
			
			else
			{
				tile_list.Insert(0, tile_prefabs[next_tile]);
				tile_list[0].SetActive(true);
				tile_collider = tile_list[0].GetComponent<BoxCollider2D>();
				tile_collider.enabled = true;
				i++;
			}
		}
	}
	
	public void move_tile()
	{
		add_next_tile();
		
		previous_tile_size = tile_list[1].GetComponent<SpriteRenderer>().bounds.size;
		tile_list[0].transform.position = new Vector3(0, tile_list[1].transform.position.y + previous_tile_size.y, 0);
	}

}
