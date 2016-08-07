using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
using System.Collections;

public class GameCenter : MonoBehaviour {

	public string leaderboardID = "com.redtapestudios.snake_and_tails.leaderboards";

    void Start () {
        AuthenticateToGameCenter();
    }

    private bool isAuthenticatedToGameCenter;
    public static void  AuthenticateToGameCenter() {
        #if UNITY_IPHONE
        Social.localUser.Authenticate(success => {
        if (success) {
            Debug.Log("Authentication successful");
        } else {
            Debug.Log("Authentication failed");
            }
        });
        #endif
    }

    public static void ReportScore(long score, string leaderboardID) {
        #if UNITY_IPHONE
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success => {
            if (success) {
            Debug.Log("Reported score successfully");
            } else {
                Debug.Log("Failed to report score");
                }
            });
        #endif
    }

    //call to show leaderboard
    public static void ShowLeaderboard() {
        #if UNITY_IPHONE
		GameCenterPlatform.ShowLeaderboardUI(leaderboardId, UnityEngine.SocialPlatforms.TimeScope.AllTime);
        #endif
    }
}