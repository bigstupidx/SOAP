using UnityEngine;
using System.Collections;
using Soomla.Profile;
using Soomla;

public class SOAPProfile : MonoBehaviour {

    public bool logged_in_fb = false;
    public bool logged_in_twitter = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Provide form so user can login in to Facebook
    public void FBLogin()
    {
        if(!SoomlaProfile.IsLoggedIn(Provider.FACEBOOK))
        {
            SoomlaProfile.Login(Provider.FACEBOOK, "facebook");
        }
        else
        {
            Debug.Log("Already logged in to Facebook!");
        }
    }


    // Post to Facebook wall
    public void postToWall()
    {
        FBLogin();

        SoomlaProfile.UpdateStory(
            Provider.FACEBOOK,
            "Scored 1000 points in Snake and Tails!",  // Message
            "Red Tape Studios",                        // Name
            "RTS FTW!",                                // Caption
            "rts_snake_tails",                         // Desc
            "https://play.google.com/store/apps/details?id=com.RedTapeStudios.MatchMayhem_01&hl=en",           // Link
            "https://lh3.googleusercontent.com/VZA4sJmj4Gw1SHzJQJredvGtQeDbUzMdyGykSA1MJW35yWN1-06ve6YuED_sbV1u2a4=h900-rw"     // Image
            );
    }


    // Provide form so user can login in to Twitter
    public void twitterLogin()
    {
        if (!SoomlaProfile.IsLoggedIn(Provider.TWITTER))
        {
            SoomlaProfile.Login(Provider.TWITTER, "twitter");
        }
        else
        {
            Debug.Log("Already logged in to Twitter!");
        }
    }


    // Post to Twitter
    public void postToTwitter()
    {
        twitterLogin();

        SoomlaProfile.UpdateStory(
            Provider.TWITTER,
            "Scored 1000 points in Snake and Tails!",  // Message
            "Red Tape Studios",                        // Name
            "RTS FTW!",                                // Caption
            "rts_snake_tails",                         // Desc
            "https://play.google.com/store/apps/details?id=com.RedTapeStudios.MatchMayhem_01&hl=en",           // Link
            "https://lh3.googleusercontent.com/VZA4sJmj4Gw1SHzJQJredvGtQeDbUzMdyGykSA1MJW35yWN1-06ve6YuED_sbV1u2a4=h900-rw"     // Image
            );
    }
}
