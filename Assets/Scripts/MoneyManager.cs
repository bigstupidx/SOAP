using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour {

    private static int current_money;

	// Use this for initialization
	void Start () 
    {
        if (!PlayerPrefs.HasKey("FreeMoney"))
        {
            PlayerPrefs.SetInt("FreeMoney", 800);
            current_money = 800;
        }
        else
        {
            current_money = PlayerPrefs.GetInt("FreeMoney");
        }

        HUDManager.updateMoneyText(current_money);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Decrease player money by amount
    public static void decrementMoney(int amount)
    {
        current_money -= amount;
        PlayerPrefs.SetInt("FreeMoney", current_money);
        HUDManager.updateMoneyText(current_money);
    }


    // Return the money the player currently has
    public static int getMoney()
    {
        return PlayerPrefs.GetInt("FreeMoney");
    }


}
