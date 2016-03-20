using UnityEngine;
using System.Collections;

public class TileLoader : MonoBehaviour {


    public GameObject[] tiles;                  // Array of all tiles in the game
    public Vector2 avatar_position;             // Current position of the avatars "head"
    private Vector2[] tile_positions;           // Array of "active" tile positions in the game world
    
    private GameObject[] coin_collectible;      // Array of coin collectible contained in the tile game object

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Fit the tile borders to the gamescreen
    private void fitBorderToScreen()
    {
        
    }


    // Select a random tile and load it to the main game screen
    private void loadTile()
    {

    }


    // Hide tiles that the avatar has passed and is no longer visible on the game screen
    private void hideTiles()
    {

    }
}
