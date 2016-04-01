using UnityEngine;
using System.Collections;

public class tile_size : MonoBehaviour 
{
	
	Vector3 rect_srpite;
	SpriteRenderer rect_srpite_renderer;
	public GameObject second_tile_ref;
	Transform second_tile_transform;
	
	// Use this for initialization
	void Start () 
	{
		rect_srpite_renderer = this.gameObject.GetComponent<SpriteRenderer>();
		rect_srpite = rect_srpite_renderer.bounds.size;
	    second_tile_transform = second_tile_ref.GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		Debug.Log("The Dimentions of the tile are: " + rect_srpite);
		Debug.Log("Second Tile Position Y is: " + this.gameObject.transform.position.y);
		
		second_tile_transform.position = new Vector3(0, this.gameObject.transform.position.y + rect_srpite.y, 0);

	}
	
}
