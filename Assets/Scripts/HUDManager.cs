using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    public GameObject star_count;
    private static Text star_count_text;
    public GameObject money_count;
    private static Text money_count_text;

    // Need to capture these references before MoneyManager and CollectibleManager start functions
    // Otherwise may get null reference error
    void Awake()
    {
        star_count_text = star_count.GetComponent<Text>();
        money_count_text = money_count.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () 
    {

	}

    public static void updateStarText(int current, int total)
    {
        star_count_text.text = string.Format("{0}/{1}", current, total);
    }


    public static void updateMoneyText(int current)
    {
        money_count_text.text = string.Format("$ {0}", current);
    }
}
