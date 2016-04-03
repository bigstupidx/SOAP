using UnityEngine;
using System.Collections;

public class avatar_collider_script : MonoBehaviour 
{
	private GameObject the_player;
	private Collision2D player_collider;

	// Use this for initialization
	void Start () 
	{

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
			// Disables the Collider2D component
			Debug.Log("This is the collider: " + coll.gameObject.name);
			coll.gameObject.SetActive(false);
		}
	}
}
