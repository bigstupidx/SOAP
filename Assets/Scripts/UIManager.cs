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

    private bool isPaused = false;
    private SOAPStoreManager store_manager_script;



	// Get reference to store manager and don't destroy the UI gameobject
	void Start () 
    {
        DontDestroyOnLoad(this.gameObject);
        store_manager_script = store_menu.GetComponentInParent<SOAPStoreManager>();
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
    }


    // Activate the game over menu and update the coin balance text
    public void activate_game_over_menu()
    {
        game_over_menu.SetActive(true);
        pause_button.SetActive(false);
        store_manager_script.setGameOverCoinText();
    }


    // Activate the store menu and update the coin balance text
    public void activate_store_menu()
    {
        store_menu.SetActive(true);
        store_manager_script.setStoreCoinText();
    }


    // Pause the game
    public void doPause()
    {
        Time.timeScale = 0;
        pause_button.SetActive(false);
        pause_menu.SetActive(true);
    }


    // Unpause the game
    public void unPause()
    {
        Time.timeScale = 1;
        pause_button.SetActive(true);
        pause_menu.SetActive(false);
    }


    // Restart the main level
    public void restartLvl()
    {
        SceneManager.LoadScene(2);
        game_over_menu.SetActive(false);
        pause_button.SetActive(true);
        //unPause();
    }


    // Return to main menu
    public void returnToMain()
    {
        unPause();
        Destroy(this.gameObject);
        SceneManager.LoadScene(1);
    }
}
