using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject avatar;           // Reference to the avatar gameobject
    public int camera_y_offset;         // The offset between the camera and the avatar
    public float camera_damp;           // Dampening effect for the camera's follow. Smaller = more dampening
    public bool cam_is_hold = false;
    public GameObject tile_spawner_ref;
    private spawn_tiles spawn_tiles_script;
	private GameObject challeneg_room_tile;
	// Use this for initialization
	void Start () 
    {
		spawn_tiles_script = tile_spawner_ref.gameObject.GetComponent<spawn_tiles>();

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

		else if(avatar.transform.position.y >= transform.position.y + camera_y_offset && cam_is_hold == true)
        {
			for (int i = 0; i < spawn_tiles_script.tile_list.Count; i++)
			{
				if (spawn_tiles_script.tile_list[i].gameObject.tag == "challenge_room")
				{
					// Set the cameras target position
					Vector3 target_pos = new Vector3(0, spawn_tiles_script.tile_list[i].gameObject.transform.position.y, -10); //- camera_y_offset, -10
		            
		            // Smoothly move the camera to the target position
		            transform.position = Vector3.Lerp(transform.position, target_pos, camera_damp);
				}
			}
        }
    }

	public void hold_camera()
	{
		cam_is_hold = true;
	}

	public void release_camera()
	{
		cam_is_hold = false;
	}
}

