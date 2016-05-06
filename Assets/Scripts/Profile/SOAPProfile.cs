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


    // Provide form so user can login in to Facebook
    public void FBLogin()
    {
        SoomlaProfile.Login(Provider.FACEBOOK);
    }


    // Post to Facebook wall
    public void postToWall()
    {
        SoomlaProfile.UpdateStory(
            Provider.FACEBOOK,
            "Scored 1000 points in Snake and Tails!",  // Message
            "Red Tape Studios",                        // Name
            "RTS FTW!",                                // Caption
            "rts_snake_tails",                         // Desc
            "http://www.redtapestudios.com",           // Link
            "https://static.wixstatic.com/media/6ad19c_bc11e059d2d1400785568112032d4638.png/v1/fill/w_704,h_396,al_c,usm_0.66_1.00_0.01/6ad19c_bc11e059d2d1400785568112032d4638.png"     // Image
            );
    }


    // Provide form so user can login in to Twitter
    public void twitterLogin()
    {
        SoomlaProfile.Login(Provider.TWITTER);
    }


    // Post to Twitter
    public void postToTwitter()
    {
        SoomlaProfile.UpdateStory(
            Provider.TWITTER,
            "Scored 1000 points in Snake and Tails!",  // Message
            "Red Tape Studios",                        // Name
            "RTS FTW!",                                // Caption
            "rts_snake_tails",                         // Desc
            "http://www.redtapestudios.com",           // Link
            "https://static.wixstatic.com/media/6ad19c_bc11e059d2d1400785568112032d4638.png/v1/fill/w_704,h_396,al_c,usm_0.66_1.00_0.01/6ad19c_bc11e059d2d1400785568112032d4638.png"     // Image
            );
    }
}
