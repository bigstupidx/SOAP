using UnityEngine;
using System.Collections;
using ChartboostSDK;

public class CBAds : MonoBehaviour {


    private int ad_frequency = 6;   // Ads appear after this many game overs have appeared
    private int go_count = 0;

	// Use this for initialization
	void Start () 
    {        
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Show ads at the game over screen
    public void showGameOverAds()
    {
        go_count++;

        if (go_count % ad_frequency == 0)
        {
            Chartboost.showInterstitial(CBLocation.GameOver);
            Debug.Log("show the ads now!");
        }
    }
}



