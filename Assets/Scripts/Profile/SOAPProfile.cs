using UnityEngine;
using System.Collections;
using Soomla.Profile;
using Soomla;

public class SOAPProfile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FBLogin()
    {
        SoomlaProfile.Login(Provider.FACEBOOK);
    }
}
