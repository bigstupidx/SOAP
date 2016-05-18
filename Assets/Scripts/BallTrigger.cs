using UnityEngine;
using System.Collections;


//
// This script is on the tile prefab and the obstacles are put into their corresponding arrays
// for further manipulation in the code

public class BallTrigger : MonoBehaviour {

    public GameObject[] ball_triggers;
    public GameObject[] ball_groups;
    public GameObject random;

    public float force_mag;

    private Vector2 force_push_left;
    private Vector2 force_push_right;
    private Vector2 force_push_up;
    private float[] force_array;

    public GameObject avatar;


    // Use this for initialization
	void Start () 
	{
        getBallChildren(random);
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (obstacle_manager_script.falling_obstacles.Length > 0)
        {
            if (obstacle_trigger.IsTouching(the_player.GetComponent<CircleCollider2D>()))
            {
                obstacle_manager_script.dropBalls();
            }

            else if (obstacle_trigger_reset.IsTouching(the_player.GetComponent<CircleCollider2D>()))
            {
                for (int i = 0; i < obstacle_manager_script.falling_obstacles.Length; i++)
                {
                    obstacle_manager_script.falling_obstacles[i].gameObject.transform.position = falling_obj_position_list[i];
                    obstacle_manager_script.falling_obstacles[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
            }
        }
	}


    private void getBallChildren(GameObject random)
    {
        foreach (Transform child in random.transform)
        {
            Debug.Log(child.gameObject.name);
        }
    }


    //public void dropBalls()
    //{
    //    for (int i = 0; i < falling_obstacles.Length; i++)
    //    {
    //        if(falling_obstacles[i].transform.parent.parent.parent.gameObject.activeSelf == true)
    //        {
    //            falling_obstacles[i].GetComponent<Rigidbody2D>().isKinematic = false;

    //            if(falling_obstacles[i].transform.parent.gameObject.tag == "force_push_left")
    //            {
    //                falling_obstacles[i].GetComponent<Rigidbody2D>().AddForce(force_push_left);
    //            }

    //            if(falling_obstacles[i].transform.parent.gameObject.tag == "force_push_right")
    //            {
    //                falling_obstacles[i].GetComponent<Rigidbody2D>().AddForce(force_push_right);
    //            }

    //            if(falling_obstacles[i].transform.parent.gameObject.tag == "force_push_up")
    //            {
    //                falling_obstacles[i].GetComponent<Rigidbody2D>().AddForce(force_push_up);
    //            }
    //        }
    //    }
    //}
}
