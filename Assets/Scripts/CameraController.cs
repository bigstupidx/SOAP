using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private AvatarController avatar_controller_script;  // Reference to the avatar controller script
    private float camera_speed; // The speed at which the camera moves
    private Vector2 camera_position;    // The cameras current position

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Move the camera
    private void moveCamera()
    {
        string direction = avatar_controller_script.getAvatarDirection();
        // code
    }
}
