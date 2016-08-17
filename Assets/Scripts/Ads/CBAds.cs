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

    // Show ads at the game over screen and unlock death achievements
    public void showGameOverAds()
    {
        go_count++;

        string death_count = go_count.ToString();

        // Unlock achievement for dying specific number of times
        #if UNITY_ANDROID
            switch (death_count)
            {
                case "10":
                    Achievements.justGettingTheHangOfItAchievement();
                    break;
                case "20":
                    Achievements.thisGetsEasierRightAchievement();
                    break;
                case "30":
                    Achievements.masochistAchievement();
                    break;
                case "50":
                    Achievements.soMuchDeathAchievement();
                    break;
            }
        #endif

        if (go_count % ad_frequency == 0)
        {
            Chartboost.showInterstitial(CBLocation.GameOver);
            Debug.Log("show the ads now!");
        }
    }
}



