using UnityEngine;
using System.Collections;

public class MovingObstacle : MonoBehaviour 
{
	public float maxMove=0.1f;
	public float turnRate=10;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Rotate(0, 0, 50 * Time.deltaTime);
	}
}
