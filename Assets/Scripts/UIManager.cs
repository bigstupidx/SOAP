using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //public GameObject[] ui_menus;

    public GameObject start_menu;
    public GameObject store_menu;
    public GameObject pause_menu;
    public GameObject option_menu;
    public GameObject game_over_menu;
    public GameObject pause_button;
    public GameObject game_screen_score_text;
    public static GameObject game_screen_grow_counter_text;
    public AvatarTailSwap avatar_swap_script;
    public Tutorial tutorial_script;
    public Toggle option_classic_toggle;
    public Toggle option_swipe_toogle;
    public Toggle option_arrow_toogle;

    private bool isPaused = false;
    private SOAPStoreManager store_manager_script;
    private PointManager point_manager_script;
    private CBAds cbads_script;
    private bool activate_tutorial = false;
    private GameObject arrow_container;
    private int arrow_load_count = 0;

	private Button pause_play_btn;
	private Button go_play_btn;

    public static bool is_paused = false;       // Used in TouchInput to ignore swipe when in pause menu

	// Get reference to store manager and don't destroy the UI gameobject
	void Start () 
    {
        DontDestroyOnLoad(this.gameObject);
        store_manager_script = store_menu.GetComponentInParent<SOAPStoreManager>();
        cbads_script = game_over_menu.GetComponentInParent<CBAds>();
        point_manager_script = this.GetComponent<PointManager>();

        game_screen_grow_counter_text = GameObject.Find("game_screen_grow_counter_txt");
        setGrowCounterState(false);

        // Create control type key if it doesn't exist
        bool control_type_exists = PlayerPrefs.HasKey("ControlType");

        if (!control_type_exists)
        {
            PlayerPrefs.SetString("ControlType", TouchInput.swipe_control);
        }

        // Toogle the control type in the option screen
        syncToggle();
	}

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.X))
        {
        	doPause();
        }
	}


    // Load gamescreen and disable the start menu
    public void startGame()
    {
        start_menu.SetActive(false);
        SceneManager.LoadScene(2);
        pause_button.SetActive(true);
        game_screen_score_text.SetActive(true);
        //game_screen_grow_counter_text.SetActive(true);
    }


    // Display arrow control if it was the last loaded control
    void OnLevelWasLoaded(int level)
    {
        if (level == 2 )
        {
            string control_type = PlayerPrefs.GetString("ControlType");
            arrow_container = GameObject.Find("control_canvas/arrow_ui_gr");

            // Get arrow container game object - used to show arrows when arrow control selected
            //if (control_type == TouchInput.arrow_control && arrow_load_count < 1)
            if (control_type == TouchInput.arrow_control)
            {
                toggleArrowUI(true);
                arrow_load_count++;
            }
        }
    }


    // Set the option control toggle
    public void syncToggle()
    {
        string control_type = PlayerPrefs.GetString("ControlType");

        if (control_type == TouchInput.swipe_control)
        {

            option_swipe_toogle.isOn = true;
            option_classic_toggle.isOn = false;
            option_arrow_toogle.isOn = false;
        }

        else if (control_type == TouchInput.classic_control)
        {
            option_swipe_toogle.isOn = false;
            option_classic_toggle.isOn = true;
            option_arrow_toogle.isOn = false;
        }

        else if (control_type == TouchInput.arrow_control)
        {
            option_swipe_toogle.isOn = false;
            option_classic_toggle.isOn = false;
            option_arrow_toogle.isOn = true;
        }
    }


    // Activate the game over menu and update the coin balance text
    public void activate_game_over_menu()
    {
        cbads_script.showGameOverAds();
        game_over_menu.SetActive(true);
        pause_button.SetActive(false);
        game_screen_score_text.SetActive(false);
        store_manager_script.setGameOverCoinText();

        // Update the score texts
        point_manager_script.updateBestScoreText();
        point_manager_script.updateCurrentScoreText();

		go_play_btn = GameObject.Find("go_play_btn").GetComponent<Button>();
		go_play_btn.Select();
    }


    // Activate the store menu and update the coin balance text
    public void activate_store_menu()
    {
        store_menu.SetActive(true);
        // TODO: Only activate this for TVOS
        //store_manager_script.set_back_button_focus();
        store_manager_script.setStoreCoinText();
    }


    // Exit the store menu
    public void deactivate_store_menu()
    {
        store_menu.SetActive(false);
    }

    
    // Enter the options menu
    public void activate_options_menu()
    {
        option_menu.SetActive(true);
    }


    // Exit the options menu
    public void deactivate_options_menu()
    {
        option_menu.SetActive(false);
    }


    // Pause the game, update the coin balance text, and score texts
    public void doPause()
    {
        Time.timeScale = 0;
        pause_button.SetActive(false);
        game_screen_score_text.SetActive(false);
        pause_menu.SetActive(true);
        store_manager_script.setPauseCoinText();

        // Update the score texts
        point_manager_script.updateBestScoreText();
        point_manager_script.updateCurrentScoreText();
		pause_play_btn = GameObject.Find("pause_play_btn").GetComponent<Button>();
		pause_play_btn.Select();
        is_paused = true;
    }


    // Unpause the game
    public void unPause()
    {
        Time.timeScale = 1;
        pause_button.SetActive(true);
        game_screen_score_text.SetActive(true);
        pause_menu.SetActive(false);
        avatar_swap_script.refresh_sprites();
        is_paused = false;

        if (activate_tutorial)
        {
            activateTutorial();
        }

        activate_tutorial = false;
    }


    // Turn on the tutorial
    public void activateTutorial()
    {
        string control_type = PlayerPrefs.GetString("ControlType");

        // Wait for unpause then activate the tutorial
        if (control_type == TouchInput.swipe_control)
        {
            tutorial_script.activateSwipeTutorial();
            toggleArrowUI(false);
        }

        else if (control_type == TouchInput.classic_control)
        {
            tutorial_script.activateClassicTutorial();
            toggleArrowUI(false);
        }

        else if (control_type == TouchInput.arrow_control)
        {
            tutorial_script.activateArrowTutorial();
            toggleArrowUI(true);
        }
    }


    // Activate or deactivate the arrow controls for the arrow control mechanism
    public void toggleArrowUI(bool state)
    {
        foreach (Transform arrow in arrow_container.transform)
        {
            arrow.gameObject.SetActive(state);
        }
    }

    // Restart the main level
    public void restartLvl()
    {
        SceneManager.LoadScene(2);
        game_over_menu.SetActive(false);
        pause_button.SetActive(true);
        game_screen_score_text.SetActive(true);
        point_manager_script.resetScore();

        if (activate_tutorial)
        {
            activateTutorial();
        }

        activate_tutorial = false;

        //game_screen_grow_counter_text.SetActive(true);
        //unPause();
    }


    // Set the control type
    public void setControlType(string control_type)
    {
        PlayerPrefs.SetString("ControlType", control_type);
        TouchInput.control_type = control_type;

        // Activate the tutorial for the controls
        activate_tutorial = true;
    }


    // Activate the grow counter text
    public static void setGrowCounterState(bool state)
    {
        game_screen_grow_counter_text.SetActive(state);
    }
}


