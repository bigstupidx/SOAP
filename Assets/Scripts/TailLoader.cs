using UnityEngine;
using System.Collections;

public class TailLoader : MonoBehaviour
{

    public GameObject tail_instance;    // Reference to the tail element
    private int num_tails_collected;    // Number of tails collected in the challenge room
    private int total_tails_collected;  // Number of tails collected throughout the entire game
    private GameObject challenge_room_script;   // Reference to the challenge room script


	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Spawns a tail element for the player to pick up when in a challenge room
    // Spawn at a random (?) location in the challenge room
    // Gets called everytime avatar collects tail
    public void loadTail()
    {
        if (total_tails_collected < challenge_room_script.GetComponent<ChallengeRoom>().getSpawnNumber())
        {
            // load the tail
            num_tails_collected++;
            total_tails_collected++;

            string num_tails = total_tails_collected.ToString();

            // Unlock achievement for collecting specific number of tails
            switch (num_tails)
            {
                case "9":
                    Achievements.pythonAchievement();
                    break;
                case "15":
                    Achievements.anacondaAchievement();
                    break;
                case "21":
                    Achievements.titanoboaAchievement();
                    break;
            }
        }
    }


    // Reset tails collected when exiting challenge room
    public void resetTailCount()
    {
        num_tails_collected = 0;
    }


}
