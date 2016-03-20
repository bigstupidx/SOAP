using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {

    private float previous_avatar_position;     // The avatars position during the last frame
    private float current_avatar_position;      // The avatars position during the current frame
    private Vector2 avatarDirection;            // The direction the avatar is moving
    private int speed;                          // The speed at which the avatar moves


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Return which side of the screen was tapped
    private string screenTap()
    {
        return "right";
    }


    // Turn the avatar in a clockwise direction
    private void turnClockwise()
    {

    }


    // Turn the avatar in a counter-clockwise direction
    private void turnCounterClockwise()
    {

    }


    // Return the direction the avatar is currently travelling
    public string getAvatarDirection()
    {
        string direction = "up";
        return direction;
    }


    // Moves the avatar at a constant speed in the direction specified
    private void moveAvatar(string direction)
    {

    }
}
