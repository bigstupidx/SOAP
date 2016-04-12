using UnityEngine;
using System.Collections;


//
// This script is on the tile prefab and the obstacles are put into their corresponding arrays
// for further manipulation in the code

public class ObstacleManager : MonoBehaviour {

    public GameObject[] spike_obstacles;       // Array of "spike" type obstacles contained in the tile game object
    public GameObject[] moving_wall_obstacles; // Array of "moving wall" type obstacles contained in the tile game object
    public GameObject[] moving_platform_obstacles; // Array of "moving platform" type obstacles contained in the tile game object
    public GameObject[] spinning_obstacles;    // Array of "spinning" type obstacles contained in the tile game object
    public GameObject[] static_obstacles;      // Array of "static" type obstacles contained in the tile game object

    private int[] spike_speed = { 5, 9, 12 };        // Speed at which spikes moves (mapped to spike_obstacles array)
    private int[] wall_speed = { 5, 9, 12 };         // Speed at which wall moves (mapped to moving_wall_obstacles array)
    private int[] platform_speed = { 1, 3, 5 };     // Speed at which platforms moves (mapped to moving_platform_obstacles array)
    private int[] spinning_speed = { 30, 50, 70 };     // Speed at which spinners rotates (mapped to spinning_obstacles array)

    private float[] spike_timing = { 8, 2, 3, 4 };   // Time offset at which spikes begin to move after entering the tile

	// The above can be done for other obstacles if necessary

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Move spikes in the tile
    private void moveSpikes()
    {
        for (int i = 0; i < spike_obstacles.Length; i++)
        {
            // code to move spike and time their offsets (if required)
        }
    }


    // Move walls in the tile
	public void moveWalls()
    {
        for (int i = 0; i < moving_wall_obstacles.Length; i++)
        {
            // code to move walls and time their offsets (if required)
			if (moving_wall_obstacles[i].GetComponent<IsMoving>().is_moving_right == true)
			{
				moving_wall_obstacles[i].transform.Translate(platform_speed[0] * Time.deltaTime, 0, 0);
			}

			else
			{
				moving_wall_obstacles[i].transform.Translate(platform_speed[0] * -Time.deltaTime, 0, 0);
			}
        }
    }

    // Same as obove for other arrays (other than static_obstacles)

	public void spinWalls()
    {
		for (int i = 0; i < spinning_obstacles.Length; i++)
        {
            // code to move walls and time their offsets (if required)
			spinning_obstacles[i].transform.Rotate(0, 0, spinning_speed[1] * Time.deltaTime);
        }
    }
}
