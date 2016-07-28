//using UnityEngine;
//using System.Collections;

//// This script is on every challenge room tile

//public class ChallengeRoom : MonoBehaviour {

//    private TailLoader load_tails_script;
//    private static readonly int[] room_spawn_number = {5, 6, 8, 10, 12};    // Defines how many tails to spawn for each challenge room 
//                                                                            // (i.e.) challenge room 1 = 5, challenge room 2 = 6, etc...
//    private int spawn_number; 


//    // Use this for initialization
//    void Start () 
//    {
//        getSpawnNumber();
//    }
	
//    // Update is called once per frame
//    void Update () {
	
//    }


//    // Return the number of tails to spawn
//    public int getSpawnNumber()
//    {
//        spawn_number = room_spawn_number[2];
//        return spawn_number;
//    }


//    // Each challenge room tile should have a trigger
//    // When avatar enters trigger this function is called
//    public void onEnter()
//    {
//        // Load tail when entering the challenge room
//        //load_tails_script.loadTail();
//    }


//    // Unlocks the path out of the challenge room
//    private void unlockPath()
//    {
//        load_tails_script.resetTailCount();
//    }
//}
