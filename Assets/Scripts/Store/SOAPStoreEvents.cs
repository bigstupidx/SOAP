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


    // Change inventory balance on gamescreen when item purchased
    public void onItemPurchased(PurchasableVirtualItem pvi, string payload)
    {
        Debug.Log("Bought stuff with real money");
    }


    // Change inventory balance when item balance changed (by clicking power-up button from gamescreen)
    public void OnGoodBalanceChanged(VirtualGood vg, int balance, int amountAdded)
    {
        // Code
    }


    // Change the currency balance text when the balance changed
    public void OnCurrencyBalanceChanged(VirtualCurrency vc, int balance, int amountAdded)
    {
        GameObject temp_1 = GameObject.Find("store_ui_gr");
        if (temp_1 != null) { store_manager_script = temp_1.GetComponent<SOAPStoreManager>(); }

        store_manager_script.setStoreCoinText();
        store_manager_script.setGameOverCoinText();
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
