using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

    private int screen_width;           // Width of the mobile device
    private Vector2 touch_position;     // The pixel position of the players touch
    private Vector3 mouse_position;     // For testing in unity editor
    public AvatarController avatar_controller_script;   // Reference to the AvatarController script
    private float time_of_last_tap = 0;     // The time when the last tap occured
    private float minimum_tap_time = 0.3f;  // Anything under this number is considered a double tap
    public bool tap_valid = true;           // Is the tap a double tap; when a double tap occurs this is false
    private bool side_touched;
    private bool pre_side_touched;

    private Touch initial_touch = new Touch();
    private float swipe_distance = 0;
    private bool has_swiped = false;

	// Use this for initialization
	void Start () 
    {
        // Get screen width
        screen_width = Screen.width;
	}
	
	// Update is called once per frame

	void Update () 
    {
        //if (Input.touchCount == 1)
        //{
        //    sideTouched();
        //}

        //sideTouched();
        //editorSideTouched();
		swipe_controls();
	}


    // Determine whether user clicked on right or left side of the screen
    public void sideTouched()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began && !BlockRaycast.IsPointerOverUIObject())
        {
            // Left = true right = false
            touch_position = Input.GetTouch(0).position;
            side_touched = touch_position.x <= screen_width/2;
            tap_valid = Time.time > time_of_last_tap + minimum_tap_time || side_touched != pre_side_touched;
            avatar_controller_script.setTapValid(tap_valid);

            // Check if the player tapped too fast
            //tap_valid = Time.time > time_of_last_tap + minimum_tap_time;
            //avatar_controller_script.setTapValid(tap_valid);
            //touch_position = Input.GetTouch(0).position;

            // Left = turn ccw, Right = turn cw
            //if (touch_position.x <= screen_width / 2)
            if (side_touched)
            {
                //avatar_controller_script.rotate_avatar(Mathf.PI/2);
            }

            else
            {
                //avatar_controller_script.rotate_avatar(-Mathf.PI/2);
            }

            time_of_last_tap = Time.time;
            pre_side_touched = side_touched;
        }
    }


     //For testing in the editor
    public void editorSideTouched()
    {
        if (Input.GetMouseButtonDown(0) && !BlockRaycast.IsPointerOverUIObject())
        {

            mouse_position = Input.mousePosition;
            side_touched = mouse_position.x <= screen_width/2;
            tap_valid = Time.time > time_of_last_tap + minimum_tap_time || side_touched != pre_side_touched;
            avatar_controller_script.setTapValid(tap_valid);

            //// Check if the player tapped too fast
            //tap_valid = Time.time > time_of_last_tap + minimum_tap_time;
            //avatar_controller_script.setTapValid(tap_valid);
            //mouse_position = Input.mousePosition;

            //if (mouse_position.x <= screen_width / 2)
            if (side_touched)
            {
                //avatar_controller_script.rotate_avatar(Mathf.PI/2);
            }

            else
            {
                //avatar_controller_script.rotate_avatar(-Mathf.PI/2);
            }

            time_of_last_tap = Time.time;
            pre_side_touched = side_touched;
        }
    }

	public void swipe_controls()
	{
		foreach(Touch touch in Input.touches)
        {

        	if (touch.phase == TouchPhase.Began)
        	{
				initial_touch = touch;
			}

			else if (touch.phase == TouchPhase.Moved && !has_swiped)
			{
				float x_delta = initial_touch.position.x - touch.position.x;
				float y_delta = initial_touch.position.y - touch.position.y;
				bool swiped_sidways = Mathf.Abs(x_delta) > Mathf.Abs(y_delta);
				swipe_distance = Mathf.Sqrt((x_delta * x_delta) + (y_delta * y_delta));

				if (swipe_distance > 10f)
				{
					// Swipe left
					if (swiped_sidways && x_delta > 0)
					{
						if (avatar_controller_script.previous_vector_avatar_direction == Vector3.up)
						{
							avatar_controller_script.rotate_avatar(Mathf.PI/2);
						}

						else if (avatar_controller_script.previous_vector_avatar_direction == Vector3.down)
						{
							avatar_controller_script.rotate_avatar(-Mathf.PI/2);
						}

						else
						{

						}
					}

					// Swipe Right
					else if (swiped_sidways && x_delta <= 0)
					{

						if (avatar_controller_script.previous_vector_avatar_direction == Vector3.up)
						{
							avatar_controller_script.rotate_avatar(-Mathf.PI/2);
						}

						else if (avatar_controller_script.previous_vector_avatar_direction == Vector3.down)
						{
							avatar_controller_script.rotate_avatar(Mathf.PI/2);
						}

						else
						{

						}
					}

					// Swipe Down
					else if (!swiped_sidways && y_delta > 0)
					{

						if (avatar_controller_script.previous_vector_avatar_direction == Vector3.left)
						{
							avatar_controller_script.rotate_avatar(Mathf.PI/2);
						}

						else if (avatar_controller_script.previous_vector_avatar_direction == Vector3.right)
						{
							avatar_controller_script.rotate_avatar(-Mathf.PI/2);
						}

						else
						{

						}
					}

					// Swipe Up
					else if (!swiped_sidways && y_delta <= 0)
					{

						if (avatar_controller_script.previous_vector_avatar_direction == Vector3.left)
						{
							avatar_controller_script.rotate_avatar(-Mathf.PI/2);
						}

						else if (avatar_controller_script.previous_vector_avatar_direction == Vector3.right)
						{
							avatar_controller_script.rotate_avatar(Mathf.PI/2);
						}

						else
						{

						}
					}

					has_swiped = true;
				}
			}

			else if (touch.phase == TouchPhase.Ended)
			{
				initial_touch = new Touch();
				has_swiped = false;
				Debug.Log("Previous direction: " + avatar_controller_script.previous_vector_avatar_direction.ToString());
			}
        }
	}

}


