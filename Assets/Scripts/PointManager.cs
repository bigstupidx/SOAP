using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {

    private int current_score = -1;          // The players current score
    private UIManager ui_manager_script;    // Used for updating various scores (pause, game over, game screen)
    
    public Text game_screen_score;
    public Text[] best_score_text_list;
    public Text[] current_score_text_list;


	// Use this for initialization
	void Start () 
    {
        // Create best score key if it doesn't exist
        bool score_key_exists = PlayerPrefs.HasKey("BestScore");

        if (!score_key_exists)
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }

        // Get reference to UI manager
        GameObject temp_1 = GameObject.Find("UI_canvas");
        if (temp_1 != null) { ui_manager_script = temp_1.GetComponent<UIManager>(); }
	}


    // Update the players score in the game screen
    public void update_score()
    {
        current_score++;
        game_screen_score.text = current_score.ToString();

        int best_score = getScore();
        if (current_score > best_score)
        {
            setScore(current_score);
        }
    }

    // Get the best score
    public int getScore()
    {
        return PlayerPrefs.GetInt("BestScore");
    }


    // Set a new best score
    public void setScore(int score)
    {
        PlayerPrefs.SetInt("BestScore", score);
    }


    // Update the current score text in the game over and pause screens
    public void updateCurrentScoreText()
    {
        foreach (Text txt in current_score_text_list)
        {
            txt.text = current_score.ToString();
        }
    }


    // Update the best score text in the game over and pause screens
    public void updateBestScoreText()
    {
        int best_score = getScore();

        foreach (Text txt in best_score_text_list)
        {
            txt.text = best_score.ToString();
        }
    }


    // Reset the current score
    public void resetScore()
    {
        current_score = -1;
    }

}
