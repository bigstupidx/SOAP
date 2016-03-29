using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;

public class Store_Init : MonoBehaviour 
{
	public GameObject image_ref;
	private Animator image_anim;
	private Animation fadeColorAnimationClip;
	
	// Use this for initialization
	void Start () 
	{	
		SoomlaStore.Initialize(new SOAPStoreAssets());
	}
	

	
	public void LoadDelayed()
	{
		//Load the selected scene, by scene index number in build settings
        //Application.LoadLevel(1); // Load the classic start screen
	}
}
