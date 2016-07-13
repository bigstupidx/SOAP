using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewardedAvatars : MonoBehaviour {

    public const string cyborg_avatar_rwd = "cyborg_avatar";
    public const string cyborg_tail_rwd = "cyborg_tail";
    public const string crab_avatar_rwd = "crab_avatar";
    public const string crab_tail_rwd = "crab_tail";


    // Dictionary of reward avatar and tails with their position in the player prefs "Reward" key string
    public static readonly Dictionary<string, int> avatar_balance_index_map = new Dictionary<string, int>
    {   
        {"cyborg_avatar", 0},
        {"cyborg_tail", 1},
        {"crab_avatar", 2},
        {"crab_tail", 3},
    };

    // Dictionary that explains how to earn each avatar
    public static readonly Dictionary<string, string> avatar_earn_text_map = new Dictionary<string, string>
    {   
        {"cyborg_avatar", "Get a score of 20 to unlock."},
        {"cyborg_tail", "Get a score of 20 to unlock."},
        {"crab_avatar", "Post to Facebook to unlock."},
        {"crab_tail", "Post to Facebook to unlock."},
    };


	// Use this for initialization
	void Start () 
    {
        bool reward_key_exists = PlayerPrefs.HasKey("Reward");

        if (!reward_key_exists)
        {
            PlayerPrefs.SetString("Reward", "0_0_0_0");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setAvatarUnlockStatus(string name)
    {

    }


    // Checks the balance player prefs key to see if the avatar is unlocked
    public static bool isAvatarUnlocked(string name)
    {
        string reward_key = getRewardKey();
        string[] avatar_balance = reward_key.Split('_');
        int balance_position = avatar_balance_index_map[name];

        return avatar_balance[balance_position] == "1" ? true : false;
    }


    // Increments the balance contained in the player prefs "Reward" key
    public static void incrementAvatarBalance(string name)
    {
        string reward_key = getRewardKey();
        string[] avatar_balance = reward_key.Split('_');
        int balance_position = avatar_balance_index_map[name];

        avatar_balance[balance_position] = "1";

        string new_reward_key = string.Join("_", avatar_balance);

        //foreach (string balance in avatar_balance)
        //{
        //    new_reward_key = new_reward_key + balance + "_";
        //    Debug.Log(new_reward_key);
        //}

        setRewardKey(new_reward_key);
    }


    // 
    public static void setRewardKey(string reward_index)
    {
        PlayerPrefs.SetString("Reward", reward_index);
    }


    // Return the string representing the balances of the rewarded avatars and tails
    public static string getRewardKey()
    {
        return PlayerPrefs.GetString("Reward");
    }
}
