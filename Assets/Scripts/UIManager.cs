using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject[] ui_menus;
    public GameObject pause_menu;
    private bool isPaused = false;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(this.gameObject);
	}
	

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused && SceneManager.GetActiveScene().buildIndex > 0)
        {
           doPause();
        }

        else if (Input.GetButtonDown("Cancel") && isPaused && SceneManager.GetActiveScene().buildIndex > 0)
        {
            unPause();
        }
	}


    public void startGame()
    {
        setMenuState(false);
        SceneManager.LoadScene(1);
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


    // Pause the game
    private void doPause()
    {
        isPaused = !isPaused;
        Time.timeScale = 0;
        pause_menu.SetActive(true);
    }

    // Unpause the game
    public void unPause()
    {
        isPaused = !isPaused;
        Time.timeScale = 1;
        pause_menu.SetActive(false);
    }

    public void restartLvl()
    {
        Debug.Log("Restarting the level!");
        SceneManager.LoadScene(1);
        unPause();
    }

    // Return to main menu
    public void returnToMain()
    {
        unPause();
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }
}
