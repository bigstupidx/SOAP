// -
// This script registers to listen for the specified subset of events 
// fired by Soomla events. It then handles these events.
//
// IMPORTANT: Put this class on a gameobject that is always active, 
// never destroyed, and only loads once (SPLASH SCREEN)
// -


using UnityEngine;
using System.Collections;
using Soomla.Profile;
using UnityEngine.UI;

public class SOAPProfileEvents : MonoBehaviour {

    private SOAPProfile soap_profile_script;

	// Register to listen to the following Soomla events
	void Start () 
    {
        // These event catchers need to be on a gameobject that is never turned off, 
        ProfileEvents.OnLoginFinished += onLoginFinished;
        //ProfileEvents.OnUserProfileUpdated += OnUserProfileUpdated;
        DontDestroyOnLoad(this.gameObject);
	}


    // Handle this event with your game-specific behavior:
    public void onLoginFinished(UserProfile userProfileJson, bool autoLogin, string payload)
    {
        // userProfileJson is the user's profile from the logged in provider
        // autoLogin will be "true" if the user was logged in using the AutoLogin functionality
        // payload is an identification string that you can give when you initiate the login operation and want to receive back upon its completion
        GameObject temp_1 = GameObject.Find("options_container");
        if (temp_1 != null) { soap_profile_script = temp_1.GetComponent<SOAPProfile>(); }
        


        Debug.Log(userProfileJson);
    }
}
