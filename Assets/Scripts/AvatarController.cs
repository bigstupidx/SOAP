using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarController : MonoBehaviour {

    private float min_distance = 0.70f;         // The minimum distance between elements in the snake
    private Vector3 previous_avatar_position;   // The avatars position before it travelled min_distance 
    private string avatar_direction;            // The direction the avatar is moving
    private Vector3 avatar_vector_direction;    // The avatar vector direction
    public float avatar_speed;                    // The speed at which the avatar moves
    public Vector2 default_avatar_position;     // The avatars starting position
    public TailMovement tail_movement_script;
    Dictionary<string, string> cw_movement = new Dictionary<string, string>();  // Defines the next direction for clockwise turn
    Dictionary<string, string> ccw_movement = new Dictionary<string, string>(); // Defines the next direction for counter-clockwise turn
    public float temp_boost = 10f;              // The boost to give avatar when a double tap occurs so avatar doesn't collide with its tail
    private bool tap_valid = true;              // False if the player double taps. Signals when to apply the boost
    public Vector3 previous_vector_avatar_direction;   // The avatars previous vector direction

    private Rigidbody2D rigid_body;     // Used to give avatar velocity

	// Use this for initialization
	void Start () 
    {
        avatar_direction = "up";
        transform.position = default_avatar_position;
        //avatar_speed = 2;
        previous_avatar_position = transform.position - new Vector3(0,min_distance,0);

        avatar_vector_direction = Vector3.up;
        previous_vector_avatar_direction = avatar_vector_direction;

        rigid_body = this.GetComponent<Rigidbody2D>();

        //InvokeRepeating("moveAvatar", 0.5f, 0.5f);
	}

    // Update is called once per frame
    void FixedUpdate()
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


    // Set whether or not a double tap occured
    public void setTapValid(bool tap)
    {
        tap_valid = tap;
    }


    // Rotate the avatar +/- 90 degrees
    // Angle provided must be in radians
    public void rotate_avatar(float angle)
    {
        float cos_angle = Mathf.Cos(angle);
        float sin_angle = Mathf.Sin(angle);
        avatar_vector_direction.x = previous_vector_avatar_direction.x * cos_angle - previous_vector_avatar_direction.y * sin_angle;
        avatar_vector_direction.y = previous_vector_avatar_direction.x * sin_angle + previous_vector_avatar_direction.y * cos_angle;
        
        // Rotate the sprite
        rotateSprite(previous_vector_avatar_direction, avatar_vector_direction);
    }


    // Rotate the sprite image when the avatar turns
    public void rotateSprite(Vector3 previous_direction, Vector3 current_direction)
    {
        Vector3 cross_product = Vector3.Cross(previous_vector_avatar_direction, avatar_vector_direction);
        if (cross_product.z > 0)
        {
            this.transform.Rotate(0, 0, 90);
        }
        else
        {
            this.transform.Rotate(0, 0, -90);
        }
    }


    // Move the avatar in the direction specified
    public void moveAvatar()
    {
        // Apply the temporary boost because the player has double tapped
        if (!tap_valid)
        {
            Vector3 previous_pos = transform.position;
            // Use fixed delta time to apply the boost otherwise the boost will not be consistent
            rigid_body.velocity = previous_vector_avatar_direction * avatar_speed;
            //transform.position += previous_vector_avatar_direction * Time.fixedDeltaTime * temp_boost;
            tap_valid = true;
        }

        //transform.position += avatar_vector_direction;
        //transform.position += avatar_vector_direction * Time.fixedDeltaTime * avatar_speed;
        rigid_body.velocity = avatar_vector_direction*avatar_speed;

        previous_vector_avatar_direction = avatar_vector_direction;
    }
}
