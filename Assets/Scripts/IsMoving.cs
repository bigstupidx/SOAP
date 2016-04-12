using UnityEngine;
using System.Collections;

public class IsMoving : MonoBehaviour 
{
	public bool is_moving_right = true;

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
		// Obstacle collision: the player "dies", avatar setActive is set to false.
        if (coll.gameObject.tag == "obstacle")
        {
			if (is_moving_right == true)
			{
				is_moving_right = false;
			}

			else
			{
				is_moving_right = true;
			}
        }
	}
}
