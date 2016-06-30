// -
// This script registers to listen for the specified subset of events 
// fired by Soomla events. It then handles these events.
//
// IMPORTANT: Put this class on a gameobject that is always active, 
// never destroyed, and only loads once (SPLASH SCREEN)
// -


using UnityEngine;
using System.Collections;
using Soomla.Store;
using UnityEngine.UI;

public class SOAPStoreEvents : MonoBehaviour {

    private SOAPStoreManager store_manager_script;

	// Register to listen to the following Soomla events
	void Start () 
    {
        // These event catchers need to be on a gameobject that is never turned off, 
        StoreEvents.OnItemPurchased += onItemPurchased;
        StoreEvents.OnGoodBalanceChanged += OnGoodBalanceChanged;
        StoreEvents.OnCurrencyBalanceChanged += OnCurrencyBalanceChanged;
        StoreEvents.OnRestoreTransactionsStarted += OnRestoreTransactionsStarted;
        StoreEvents.OnRestoreTransactionsFinished += OnRestoreTransactionsFinished;
        DontDestroyOnLoad(this.gameObject);
	}


    // Update the prices when an item is bought with real money in the store
    public void onItemPurchased(PurchasableVirtualItem pvi, string payload)
    {
        GameObject temp_1 = GameObject.Find("store_ui_gr");
        if (temp_1 != null) { store_manager_script = temp_1.GetComponent<SOAPStoreManager>(); }

        string avatar_id = pvi.ItemId;

        store_manager_script.updatePrices(avatar_id);

        // Unlock achievement for buying an avatar or tail with real money
        if (avatar_id.Contains("avatar"))
        {
            Achievements.massiveFacialReconstructionAchievement();
        }
        else
        {
            Achievements.sheddingSeasonAchievement();
        }
    }


    // Update the prices when an item is bought with virtual currency in the store
    public void OnGoodBalanceChanged(VirtualGood vg, int balance, int amountAdded)
    {
        GameObject temp_1 = GameObject.Find("store_ui_gr");
        if (temp_1 != null) { store_manager_script = temp_1.GetComponent<SOAPStoreManager>(); }

        string avatar_id = vg.ItemId;

        store_manager_script.updatePrices(avatar_id);

        // Unlock achievement for buying an avatar or tail with virtual currency
        if (avatar_id.Contains("avatar"))
        {
            Achievements.massiveFacialReconstructionAchievement();
        }
        else
        {
            Achievements.sheddingSeasonAchievement();
        }
    }


    // Change the currency balance text when the balance changed
    public void OnCurrencyBalanceChanged(VirtualCurrency vc, int balance, int amountAdded)
    {
        GameObject temp_1 = GameObject.Find("store_ui_gr");
        if (temp_1 != null) { store_manager_script = temp_1.GetComponent<SOAPStoreManager>(); }

        store_manager_script.setStoreCoinText();
        store_manager_script.setGameOverCoinText();
        store_manager_script.setPauseCoinText();

        // Unlock achievement for accumulating coins
        if (balance >= 20000 && balance < 100000)
        {
            Achievements.forARainyDayAchievement();
        }

        if (balance > 100000)
        {
            Achievements.mustHaveThemAllAchievement();
        }
    }


    // Print message saying transactions are being restored (necessary for iOS)
    public void OnRestoreTransactionsStarted()
    {
        Debug.Log("The transactions are being restored.");
    }


    // Print message saying transactions are restored (necessary for iOS)
    public void OnRestoreTransactionsFinished(bool success)
    {
        Debug.Log("The transactions are now restored.");
    }
}
