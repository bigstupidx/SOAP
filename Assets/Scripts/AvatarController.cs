using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarController : MonoBehaviour {

    private float min_distance = 0.65f;         // The minimum distance between elements in the snake
    private Vector3 previous_avatar_position;   // The avatars position when it travelled min_distance 
    private string avatar_direction;            // The direction the avatar is moving
    private Vector3 avatar_vector_direction;    // The avatar vector direction
    private int avatar_speed;                   // The speed at which the avatar moves
    public Vector2 default_avatar_position;     // The avatars starting position
    public TailMovement tail_movement_script;
    Dictionary<string, string> cw_movement = new Dictionary<string, string>();  // Defines the next direction for clockwise turn
    Dictionary<string, string> ccw_movement = new Dictionary<string, string>(); // Defines the next direction for counter-clockwise turn
    public float temp_boost = 50f;              // The boost to give avatar when a double tap occurs so avatar doesn't collide with its tail
    private bool tap_valid = true;              // False if the player double taps. Signals when to apply the boost
    private Vector3 previous_vector_avatar_direction;   // The avatars previous vector direction


	// Use this for initialization
	void Start () 
    {
        // RECODE: On restart onbecameinvisible is called which sets timescale to zero
        // this ensures timescale is reset to one when lvl is reloaded
        Time.timeScale = 1;

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
    void Update()
    {
        moveAvatar();

        float current_distance = Vector3.Distance(transform.position, previous_avatar_position);

        // Update tails if the avatar has travelled greater than min_distance
        if (current_distance >= min_distance)
        {
            tail_movement_script.tailFollow(previous_avatar_position);
            previous_avatar_position = transform.position;
        }
    }


    // When the avatar is out of the camera's view end the game
    void OnBecameInvisible()
    {
        Debug.Log("GAME OVER!");
        Time.timeScale = 0;
    }


    // Set whether or not a double tap occured
    public void setTapValid(bool tap)
    {
        tap_valid = tap;
    }


    // Turn the avatar clockwise (true) or counterclockwise (false)
    public void turnAvatar(bool rotation)
    {
        string previous_avatar_direction = avatar_direction;

        if (rotation)
        {
            avatar_direction = cw_movement[avatar_direction];
            avatar_vector_direction = determineDirection(avatar_direction);
            previous_vector_avatar_direction = determineDirection(previous_avatar_direction);
            moveAvatar();
        }
        else
        {
            avatar_direction = ccw_movement[avatar_direction];
            avatar_vector_direction = determineDirection(avatar_direction);
            previous_vector_avatar_direction = determineDirection(previous_avatar_direction);
            moveAvatar();
        }
    }




    // The vector direction the avatar must move
    public Vector3 determineDirection(string direction)
    {
        switch (direction)
        {
            case "up":
                return Vector3.up;

            case "right":
                return Vector3.right;

            case "left":
                return Vector3.left;

            case "down":
                return Vector3.down;
        }
        return Vector3.zero;
    }


    // Move the avatar in the direction specified
    public void moveAvatar()
    {
        // Apply the temporary boost because the player has double tapped
        if (!tap_valid)
        {
            Vector3 previous_pos = transform.position;
            // Use fixed delta time to apply the boost otherwise the boost will not be consistent
            transform.position += previous_vector_avatar_direction * Time.fixedDeltaTime * temp_boost;
            tap_valid = true;
        }

        transform.position += avatar_vector_direction * Time.deltaTime * avatar_speed;
    }
}
