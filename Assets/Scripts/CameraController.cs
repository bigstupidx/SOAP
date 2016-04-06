using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject avatar;           // Reference to the avatar gameobject
    public int camera_y_offset;         // The offset between the camera and the avatar
    public float camera_damp;           // Dampening effect for the camera's follow. Smaller = more dampening
    public bool cam_is_hold = false;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void FixedUpdate()
    {   
        // Only move camera if the avatar is moving upwards
		if (avatar.transform.position.y >= transform.position.y + camera_y_offset && cam_is_hold == false	)
        {
            // Set the cameras target position
            Vector3 target_pos = new Vector3(0, avatar.transform.position.y - camera_y_offset, -10);
            
            // Smoothly move the camera to the target position
            transform.position = Vector3.Lerp(transform.position, target_pos, camera_damp);

            //Debug.Log(string.Format("Target: {0}\nCurrent: {1}", target_pos, transform.position));
        }
    }

	public void hold_camera()
	{
		cam_is_hold = true;
	}
}

