using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

    private int screen_width;
    private Vector2 touch_position;
    private Vector3 mouse_position;     // For testing in unity editor
    public AvatarController avatar_controller_script;

	// Use this for initialization
	void Start () 
    {
        screen_width = Screen.width;
	}
	
	// Update is called once per frame
	void Update () 
    {
        sideTouched();
        editorSideTouched();
	}


    // Determine whether user clicked on right or left side of the screen
    public void sideTouched()
    {
        if (Input.touchCount == 1)
        {
            touch_position = Input.GetTouch(0).position;

            if (touch_position.x <= screen_width / 2)
            {
                avatar_controller_script.turnAvatar(false);
            }

            else
            {
                avatar_controller_script.turnAvatar(true);
            }
        }
    }


    // For testing in the editor
    public void editorSideTouched()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouse_position = Input.mousePosition;

            if (mouse_position.x <= screen_width / 2)
            {
                avatar_controller_script.turnAvatar(false);
            }

            else
            {
                avatar_controller_script.turnAvatar(true);
            }
        }
    }
}


