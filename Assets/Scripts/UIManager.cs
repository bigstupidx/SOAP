using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject[] ui_menus;
    public GameObject pause_menu;
    public GameObject game_over_menu;
    public GameObject pause_button;
    private bool isPaused = false;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(this.gameObject);
	}


	

	// Update is called once per frame
	void Update ()
    {

	}


    public void startGame()
    {
        setMenuState(false);

        // TODO: This may change when the splash screen is added
        SceneManager.LoadScene(1);
        pause_button.SetActive(true);
    }


    // Set start menu UI on or off depending on state argument
    private void setMenuState(bool state)
    {
        int len = ui_menus.Length;
        for (int i = 0; i < len; i++)
        {
            ui_menus[i].SetActive(state);
        }
    }


    public void activate_game_over_menu()
    {
        game_over_menu.SetActive(true);
    }

    // Pause the game
    public void doPause()
    {
        //isPaused = !isPaused;
        Time.timeScale = 0;
        pause_menu.SetActive(true);
    }

    // Unpause the game
    public void unPause()
    {
        //isPaused = !isPaused;
        Time.timeScale = 1;
        pause_menu.SetActive(false);
    }

    public void restartLvl()
    {
        // TODO: This may change when the splash screen is added
        SceneManager.LoadScene(1);
        unPause();
    }

    // Return to main menu
    public void returnToMain()
    {
        unPause();
        Destroy(this.gameObject);
        // TODO: This may change when the splash screen is added
        SceneManager.LoadScene(0);
    }
}
