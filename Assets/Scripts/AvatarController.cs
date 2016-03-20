using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarController : MonoBehaviour {

    private float previous_avatar_position;     // The avatars position during the last frame
    private float current_avatar_position;      // The avatars position during the current frame
    private string avatar_direction;            // The direction the avatar is moving
    private int speed;                          // The speed at which the avatar moves
    Dictionary<string, string> cw_movement = new Dictionary<string, string>();  // Defines the next direction for clockwise turn
    Dictionary<string, string> ccw_movement = new Dictionary<string, string>(); // Defines the next direction for counter-clockwise turn
    private Vector2 default_avatar_position = new Vector2(0, -2);   // The avatar starting position
    private int avatar_speed;   // The avatars movement speed

   

	// Use this for initialization
	void Start () 
    {
        avatar_direction = "up";
        transform.position = default_avatar_position;
        avatar_speed = 2;

        cw_movement.Add("up", "right");
        cw_movement.Add("right", "down");
        cw_movement.Add("down", "left");
        cw_movement.Add("left", "up");

        ccw_movement.Add("up", "left");
        ccw_movement.Add("left", "down");
        ccw_movement.Add("down", "right");
        ccw_movement.Add("right", "up");
	}
	
	// Update is called once per frame
	void Update () 
    {
        moveAvatar(avatar_direction);
	}


    public void testPrint()
    {
        Debug.Log("Execute test!");
    }


    // Turn the avatar clockwise (true) or counterclockwise (false)
    public void turnAvatar(bool rotation)
    {
        if (rotation)
        {
            avatar_direction = cw_movement[avatar_direction];
            moveAvatar(avatar_direction);
        }
        else
        {
            avatar_direction = ccw_movement[avatar_direction];
            moveAvatar(avatar_direction);
        }
    }


    // Move the avatar in the direction specified
    public void moveAvatar(string direction)
    {
        switch (direction)
        {
            case "up":
                transform.position += Vector3.up * Time.deltaTime * avatar_speed;
                break;

            case "right":
                transform.position += Vector3.right * Time.deltaTime * avatar_speed;
                break;

            case "left":
                transform.position += Vector3.left * Time.deltaTime * avatar_speed;
                break;

            case "down":
                transform.position += Vector3.down * Time.deltaTime * avatar_speed;
                break;
        }
    }
}
