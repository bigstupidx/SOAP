using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //public GameObject[] ui_menus;

    public GameObject start_menu;
    public GameObject store_menu;
    public GameObject pause_menu;
    public GameObject game_over_menu;
    public GameObject pause_button;
    public GameObject game_screen_score_text;
    public AvatarTailSwap avatar_swap_script;

    private bool isPaused = false;
    private SOAPStoreManager store_manager_script;
    private PointManager point_manager_script;
    private CBAds cbads_script;




	// Get reference to store manager and don't destroy the UI gameobject
	void Start () 
    {
        DontDestroyOnLoad(this.gameObject);
        store_manager_script = store_menu.GetComponentInParent<SOAPStoreManager>();
        cbads_script = game_over_menu.GetComponentInParent<CBAds>();
        point_manager_script = this.GetComponent<PointManager>();
	}

	// Update is called once per frame
	void Update ()
    {

	}


    // Load gamescreen and disable the start menu
    public void startGame()
    {
        start_menu.SetActive(false);
        SceneManager.LoadScene(2);
        pause_button.SetActive(true);
        game_screen_score_text.SetActive(true);
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
    }


    // Activate the store menu and update the coin balance text
    public void activate_store_menu()
    {
        store_menu.SetActive(true);
        store_manager_script.setStoreCoinText();
    }


    public void deactivate_store_menu()
    {
        store_menu.SetActive(false);
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
    }


    // Unpause the game
    public void unPause()
    {
        Time.timeScale = 1;
        pause_button.SetActive(true);
        game_screen_score_text.SetActive(true);
        pause_menu.SetActive(false);
        avatar_swap_script.refresh_sprites();
    }


    // Restart the main level
    public void restartLvl()
    {
        SceneManager.LoadScene(2);
        game_over_menu.SetActive(false);
        pause_button.SetActive(true);
        game_screen_score_text.SetActive(true);
        point_manager_script.resetScore();
        //unPause();
    }
}


