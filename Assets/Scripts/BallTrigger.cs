using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


//
// Logic for having falling obstacles be triggered individually 
//

public class BallTrigger : MonoBehaviour {

    public GameObject[] ball_trigger_go;
    public GameObject avatar;

    private Vector2 force_push_left = new Vector2(1.0f, 0.0f);
    private Vector2 force_push_right;
    private Vector2 force_push_up;
    private float[] force_array;
    private BoxCollider2D[] trigger_box_collider;
    private List<GameObject[]> ball_elements = new List<GameObject[]>();

    


    // Use this for initialization
	void Start () 
	{
        trigger_box_collider = new BoxCollider2D[ball_trigger_go.Length];

        for (int i = 0; i < ball_trigger_go.Length; i++)
        {
            trigger_box_collider[i] = ball_trigger_go[i].GetComponent<BoxCollider2D>();
        }

        for (int j = 0; j < ball_trigger_go.Length; j++)
        {
            ball_elements.Add(getBallChildren(ball_trigger_go[j]));
        }

        //foreach (GameObject[] go in ball_elements)
        //{
        //    foreach(GameObject ball in go){
        //        Debug.Log(ball.name);
        //    }
        //}
	}
	

	// Update is called once per frame
	void Update () 
	{

        for (int i = 0; i < trigger_box_collider.Length; i++)
        {
            if (trigger_box_collider[i].IsTouching(avatar.GetComponent<CircleCollider2D>()))
            {
                //foreach (GameObject ball in ball_elements[i])
                //{
                //    Debug.Log(ball.name);
                //}

                int force = getForce(ball_trigger_go[i].name);
                dropBalls(ball_elements[i], force);

                
                
            }
        }
    }



    // Return an array of all children under the trigger GameObject
    private GameObject[] getBallChildren(GameObject trigger)
    {
        int ball_count = trigger.transform.childCount;
        GameObject[] balls = new GameObject[ball_count];
        
        int counter = 0;

        foreach (Transform child in trigger.transform)
        {
            balls[counter] = child.gameObject;
            counter++;
        }

        return balls;
    }


    // Extract the force magnitude from the trigger name
    private int getForce(string trigger_name)
    {
        Match match = Regex.Match(trigger_name, @"_fx[0-9]+", RegexOptions.IgnoreCase);
        int force = 0;

        if (match.Success)
        {
            string key = match.Groups[0].Value;
            string force_str = key.Split(new string[] {"fx"}, StringSplitOptions.None)[1];
            force = Convert.ToInt32(force_str);
        }

        return force;
    }


    private void dropBalls(GameObject[] ball_array, int force)
    {
        foreach (GameObject ball in ball_array)
        {
            Debug.Log(ball.name);
            Debug.Log(force);

            ball.GetComponent<Rigidbody2D>().isKinematic = false;
            ball.GetComponent<Rigidbody2D>().AddForce(force_push_left*force);
        }

        //for (int i = 0; i < falling_obstacles.Length; i++)
        //{
        //    if (falling_obstacles[i].transform.parent.parent.parent.gameObject.activeSelf == true)
        //    {
        //        falling_obstacles[i].GetComponent<Rigidbody2D>().isKinematic = false;

        //        if (falling_obstacles[i].transform.parent.gameObject.tag == "force_push_left")
        //        {
        //            falling_obstacles[i].GetComponent<Rigidbody2D>().AddForce(force_push_left);
        //        }

        //        if (falling_obstacles[i].transform.parent.gameObject.tag == "force_push_right")
        //        {
        //            falling_obstacles[i].GetComponent<Rigidbody2D>().AddForce(force_push_right);
        //        }

        //        if (falling_obstacles[i].transform.parent.gameObject.tag == "force_push_up")
        //        {
        //            falling_obstacles[i].GetComponent<Rigidbody2D>().AddForce(force_push_up);
        //        }
        //    }
        //}
    }
}
