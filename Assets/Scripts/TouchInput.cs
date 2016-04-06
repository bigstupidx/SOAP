﻿using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

    private int screen_width;           // Width of the mobile device
    private Vector2 touch_position;     // The pixel position of the players touch
    private Vector3 mouse_position;     // For testing in unity editor
    public AvatarController avatar_controller_script;   // Reference to the AvatarController script
    private float time_of_last_tap = 0;     // The time when the last tap occured
    private float minimum_tap_time = 0.3f;  // Anything under this number is considered a double tap
    public bool tap_valid = true;           // Is the tap a double tap; when a double tap occurs this is false

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

        editorSideTouched();
	}


    // Determine whether user clicked on right or left side of the screen
    public void sideTouched()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began && tap_valid && !BlockRaycast.IsPointerOverUIObject())
        {
            // Check if the player tapped too fast
            tap_valid = Time.time > time_of_last_tap + minimum_tap_time;
            avatar_controller_script.setTapValid(tap_valid);
            touch_position = Input.GetTouch(0).position;

            // Left = turn ccw, Right = turn cw
            if (touch_position.x <= screen_width / 2)
            {
                avatar_controller_script.turnAvatar(false);
            }

            else
            {
                avatar_controller_script.turnAvatar(true);
            }

            time_of_last_tap = Time.time;
        }
    }


    // For testing in the editor
    public void editorSideTouched()
    {
        if (Input.GetMouseButtonDown(0) && !BlockRaycast.IsPointerOverUIObject())
        {
            tap_valid = Time.time > time_of_last_tap + minimum_tap_time;
            avatar_controller_script.setTapValid(tap_valid);
            mouse_position = Input.mousePosition;

            if (mouse_position.x <= screen_width / 2)
            {
                avatar_controller_script.turnAvatar(false);
            }

            else
            {
                avatar_controller_script.turnAvatar(true);
            }

            time_of_last_tap = Time.time;
        }
    }

}


