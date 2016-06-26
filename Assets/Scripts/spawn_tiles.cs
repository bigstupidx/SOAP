using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawn_tiles : MonoBehaviour 
{
	public GameObject[] tile_prefabs;
	private int starting_tiles;
	private int initial_tiles = 4;
	private int next_tile = 0;
	public List<GameObject> tile_list = new List<GameObject>();
	private Vector3 previous_tile_size;
	private Vector3 current_tile_size;
	private Vector3 offset_tile_size;
	private BoxCollider2D tile_collider;
	private ChallengeRoomLogic challenge_room_logic_script;
	public bool IsFirst;
	private int tile_counter = 0;

	// Use this for initialization
	void Start () 
	{
		tile_list.Clear();
		IsFirst = true;

		for(int i = 0; i < initial_tiles;)
		{
			starting_tiles = Random.Range(0, tile_prefabs.Length);

			if (i == 0)
			{
				if(tile_prefabs[starting_tiles].tag == "start_tile")
				{
					tile_list.Add(tile_prefabs[starting_tiles]);
					tile_list[i].SetActive(true);
					i++;
					tile_counter++;
				}

			}

			else
			{
				if(tile_list.Contains(tile_prefabs[starting_tiles]))
				{
					//Debug.Log("The GameObject is: " + tile_prefabs[starting_tiles]);
				}

				else
				{
					if(tile_prefabs[starting_tiles].tag == "novice")
					{
						tile_list.Add(tile_prefabs[starting_tiles]);
						tile_list[i].SetActive(true);
					}

					else
					{
						continue;
					}
					
					if (i >= 1)
					{
						previous_tile_size = tile_list[i-1].GetComponent<SpriteRenderer>().bounds.size;
						current_tile_size = tile_list[i].GetComponent<SpriteRenderer>().bounds.size;
						offset_tile_size = new Vector3(0, Mathf.Abs(current_tile_size.y - previous_tile_size.y),0);

						if (previous_tile_size.y > current_tile_size.y)
						{
							tile_list[i].transform.position = new Vector3(0, tile_list[i-1].transform.position.y + previous_tile_size.y - (offset_tile_size.y / 2), 0);
						}

						else if(previous_tile_size.y < current_tile_size.y)
						{
							tile_list[i].transform.position = new Vector3(0, tile_list[i-1].transform.position.y + current_tile_size.y - (offset_tile_size.y / 2), 0);
						}

						else
						{
							tile_list[i].transform.position = new Vector3(0, tile_list[i-1].transform.position.y + current_tile_size.y, 0);
						}

					}

	                //Debug.Log("Position is: " + tile_list[i].transform.position.y);
	                //Debug.Log("previous_tile_size is: " + previous_tile_size.y);
					i++;
					tile_counter++;

				}
			}
		}
		
		tile_list.Reverse();
		tile_collider = tile_list[3].GetComponent<BoxCollider2D>();
		tile_collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log("tile_counter: " + tile_counter);
	}
	
	
	public void add_next_tile()
	{
		IsFirst = false;
		tile_list[3].SetActive(false);
		tile_list.RemoveAt(3);
		
		for(int i = 0; i < 1;)
		{
			next_tile = Random.Range(0, tile_prefabs.Length);

			if(tile_counter <= 5) 
			{

				if(tile_list.Contains(tile_prefabs[next_tile]))
				{
					//Debug.Log("The GameObject is: " + tile_prefabs[starting_tiles]);
					continue;
				}

				if(tile_prefabs[next_tile].tag == "beginner")
				{
					tile_list.Insert(0, tile_prefabs[next_tile]);
					tile_list[0].SetActive(true);
					tile_collider = tile_list[0].GetComponent<BoxCollider2D>();
					tile_collider.enabled = true;
					i++;
					tile_counter++;
				}

				else
				{
					continue;
				}
			}

			if(tile_counter > 5  && tile_counter <= 9)
			{
				if(tile_list.Contains(tile_prefabs[next_tile]))
				{
					//Debug.Log("The GameObject is: " + tile_prefabs[starting_tiles]);
					continue;
				}

				if(tile_prefabs[next_tile].tag == "beginner" | tile_prefabs[next_tile].tag == "intermediate")
				{
					tile_list.Insert(0, tile_prefabs[next_tile]);
					tile_list[0].SetActive(true);
					tile_collider = tile_list[0].GetComponent<BoxCollider2D>();
					tile_collider.enabled = true;
					i++;
					tile_counter++;
				}

				else
				{
					continue;
				}
			}

			if(tile_counter >= 10)
			{

				if(tile_list.Contains(tile_prefabs[next_tile]))
				{
					//Debug.Log("The GameObject is: " + tile_prefabs[starting_tiles]);
					continue;
				}

				if(tile_counter % 10 == 0)
				{
					if(tile_prefabs[next_tile].tag == "challenge_room")
					{
						tile_list.Insert(0, tile_prefabs[next_tile]);
						tile_list[0].SetActive(true);
						tile_collider = tile_list[0].GetComponent<BoxCollider2D>();
						tile_collider.enabled = true;
						challenge_room_logic_script = tile_list[0].GetComponent<ChallengeRoomLogic>();
						challenge_room_logic_script.cam_hold_ref.gameObject.SetActive(true);
						i++;
						tile_counter++;
					}

					else
					{
						continue;
					}
				}

				if(tile_prefabs[next_tile].tag == "beginner" | tile_prefabs[next_tile].tag == "intermediate" | tile_prefabs[next_tile].tag == "hard")
				{
					tile_list.Insert(0, tile_prefabs[next_tile]);
					tile_list.Insert(0, tile_prefabs[next_tile]);
					tile_list[0].SetActive(true);
					tile_collider = tile_list[0].GetComponent<BoxCollider2D>();
					tile_collider.enabled = true;
					i++;
					tile_counter++;
				}
			}
		}
	}
	
	public void move_tile()
	{
		add_next_tile();
		
		previous_tile_size = tile_list[1].GetComponent<SpriteRenderer>().bounds.size;
		current_tile_size = tile_list[0].GetComponent<SpriteRenderer>().bounds.size;
		offset_tile_size = new Vector3(0, Mathf.Abs(current_tile_size.y - previous_tile_size.y),0);

		if (previous_tile_size.y > current_tile_size.y)
		{
			tile_list[0].transform.position = new Vector3(0, tile_list[1].transform.position.y + previous_tile_size.y - (offset_tile_size.y / 2), 0);
		}

		else if(previous_tile_size.y < current_tile_size.y)
		{
			tile_list[0].transform.position = new Vector3(0, tile_list[1].transform.position.y + current_tile_size.y - (offset_tile_size.y / 2), 0);
		}

		else
		{
			tile_list[0].transform.position = new Vector3(0, tile_list[1].transform.position.y + current_tile_size.y, 0);
		}

		//tile_list[0].transform.position = new Vector3(0, tile_list[1].transform.position.y + offset_tile_size.y, 0);
	}

}
