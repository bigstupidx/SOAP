using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {


    public GameObject swipe_tutorial_go;        // Game object containing tutorial instructions for swiping control
    public GameObject classic_tutorial_go;      // Game object containing tutorial instructions for tap control
    public GameObject arrow_tutorial_go;        // Game object containing tutorial instructions for arrow control
    public bool tutorial_active = false;        // Indicates whether the tutorial is active

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {   
        // Changed the tuturial screens into buttons - button presses call deactivate 
        //
        // If the tutorial is active listen for a tap and then deactivate the tutorial
        //if (tutorial_active)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        deactivateTutorial();
        //    }
        //}
	}


    // Display tutorial if first time playing the game
    void OnLevelWasLoaded(int level)
    {
        bool first_play_exists = PlayerPrefs.HasKey("FirstPlay");

        // Bring up the tutorial for the first time in the game screen
        if (level == 2 && !first_play_exists)
        {
            activateSwipeTutorial(); // swipe control is the default control
            PlayerPrefs.SetString("FirstPlay", "played");
        }
    }


    // Activate the swipe tutorial
    public void activateSwipeTutorial()
    {
        Time.timeScale = 0;
        swipe_tutorial_go.SetActive(true);
        tutorial_active = true;
    }


    // Activate the classic (tap) tutorial
    public void activateClassicTutorial()
    {
        Time.timeScale = 0;
        classic_tutorial_go.SetActive(true);
        tutorial_active = true;
    }

    
    // Activate the arrow tutorial
    public void activateArrowTutorial()
    {
        Time.timeScale = 0;
        arrow_tutorial_go.SetActive(true);
        tutorial_active = true;
    }


    // Deactivate the tutorials
    public void deactivateTutorial()
    {
        Time.timeScale = 1;
        swipe_tutorial_go.SetActive(false);
        classic_tutorial_go.SetActive(false);
        arrow_tutorial_go.SetActive(false);
        tutorial_active = false;
    }
}


