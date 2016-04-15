using UnityEngine;
using System.Collections;

public class IsMoving : MonoBehaviour 
{
	public bool is_moving = true;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		// Obstacle collision: the player "dies", avatar setActive is set to false.
        if (coll.gameObject.tag == "obstacle")
        {
			if (is_moving == true)
			{
				is_moving = false;
			}

			else
			{
				is_moving = true;
			}
        }
	}
}
