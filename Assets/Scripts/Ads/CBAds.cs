using UnityEngine;
using System.Collections;
using ChartboostSDK;

public class CBAds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Show the ads when I click the button
    public void showAds()
    {
        Chartboost.showInterstitial(CBLocation.HomeScreen);
    }
}
