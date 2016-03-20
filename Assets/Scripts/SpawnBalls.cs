using UnityEngine;
using System.Collections;

public class SpawnBalls : MonoBehaviour {

    public GameObject[] ball_obstacles; // Contains an array of ball obstacle game objects
    private int spawn_rate; // Rate at which the balls spawn on any tile
    private int screen_height;  // Height of the screen
    private int screen_width;   // Width of the screen

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Called when avatar enters the load balls trigger for the tile
    public void determineSpawn()
    {
        // if RNG > spawn_rate

    }


    // Load the ball obstacles for the tile
    private void loadBalls()
    {
        // for object in ball_obstacles array
        ballLoadPosition();
    }


    // The position to load the ball obstacle
    private void ballLoadPosition()
    {
        // RNG to set position of ball based on screen limitsw
    }
}
