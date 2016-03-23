using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarController : MonoBehaviour {

    private float min_distance = 0.65f;         // The minimum distance between elements in the snake
    private Vector3 previous_avatar_position;   // The avatars position when it travelled min_distance 
    private string avatar_direction;            // The direction the avatar is moving
    private Vector3 avatar_vector_direction;    // The avatar vector direction
    private int avatar_speed;                   // The speed at which the avatar moves
    private Vector2 default_avatar_position = new Vector2(0, -2);   // The avatars starting position
    public TailMovement tail_movement_script;
    Dictionary<string, string> cw_movement = new Dictionary<string, string>();  // Defines the next direction for clockwise turn
    Dictionary<string, string> ccw_movement = new Dictionary<string, string>(); // Defines the next direction for counter-clockwise turn


	// Use this for initialization
	void Start () 
    {
        avatar_direction = "up";
        transform.position = default_avatar_position;
        avatar_speed = 2;
        previous_avatar_position = transform.position - new Vector3(0,min_distance,0);

        cw_movement.Add("up", "right");
        cw_movement.Add("right", "down");
        cw_movement.Add("down", "left");
        cw_movement.Add("left", "up");

        ccw_movement.Add("up", "left");
        ccw_movement.Add("left", "down");
        ccw_movement.Add("down", "right");
        ccw_movement.Add("right", "up");

        avatar_vector_direction = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () 
    {
        moveAvatar();
        
        float current_distance = Vector3.Distance(transform.position, previous_avatar_position);

        // Update tails if the avatar has travelled min_distance
        if (current_distance >= min_distance)
        {
            tail_movement_script.tailFollow(previous_avatar_position);
            previous_avatar_position = transform.position;
        }
	}


    // Turn the avatar clockwise (true) or counterclockwise (false)
    public void turnAvatar(bool rotation)
    {
        if (rotation)
        {
            avatar_direction = cw_movement[avatar_direction];
            determineDirection(avatar_direction);
            moveAvatar();
        }
        else
        {
            avatar_direction = ccw_movement[avatar_direction];
            determineDirection(avatar_direction);
            moveAvatar();
        }
    }


    // The vector direction the avatar must move
    public void determineDirection(string direction)
    {
        switch (direction)
        {
            case "up":
                avatar_vector_direction = Vector3.up;
                break;

            case "right":
                avatar_vector_direction = Vector3.right;
                break;

            case "left":
                avatar_vector_direction = Vector3.left;
                break;

            case "down":
                avatar_vector_direction = Vector3.down;
                break;
        }
    }


    // Move the avatar in the direction specified
    public void moveAvatar()
    {
        transform.position += avatar_vector_direction * Time.deltaTime * avatar_speed;
    }
}
