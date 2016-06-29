using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Need to add email of users you want to test play game services features in 
// the google play linked game services under testing if the game or game services
// is in draft status. Otherwise it will appear as if nothing is happening.


public class LeaderBoard : MonoBehaviour {

    private string leaderboard_id = "CgkIpfv-ypQeEAIQAA";
    private PointManager point_manager_script;

    public GameObject start_show_leader_btn;
    public GameObject start_login_leader_btn;
    public GameObject go_post_leader_btn;
    public GameObject go_login_leader_btn;


    void Start ()
    {
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        point_manager_script = this.GetComponent<PointManager>();
    }


    // Login In Into Your Google+ Account
    public void LogIn()
    {
        Social.localUser.Authenticate ((bool success) =>
        {
            if (success) 
            {
                start_login_leader_btn.SetActive(false);
                start_show_leader_btn.SetActive(true);
                go_login_leader_btn.SetActive(false);
                go_post_leader_btn.SetActive(true);  
            } 
            else 
            {
                Debug.Log ("Login failed");
            }
        });
    }


    // Shows All Available Leaderboard
    public void OnShowLeaderBoard ()
    {
        Social.ShowLeaderboardUI(); // Show all leaderboard
        //((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard_id); // Show current (Active) leaderboard
    }


    // Adds Score To leader board
    public void OnAddScoreToLeaderBoard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(point_manager_script.getCurrentScore(), leaderboard_id, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Update Score Success");
                    Social.ShowLeaderboardUI();
                }
                else
                {
                    Debug.Log("Update Score Fail");
                }
            });
        }
    }


    // On Logout of your Google+ Account
    public void OnLogOut ()
    {
        ((PlayGamesPlatform)Social.Active).SignOut ();
    }
}


