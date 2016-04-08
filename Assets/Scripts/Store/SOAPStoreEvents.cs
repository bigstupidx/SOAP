using UnityEngine;
using System.Collections;
using Soomla.Store;
using UnityEngine.UI;

public class SOAPStoreEvents : MonoBehaviour {

    // TODO: PUT THIS CLASS ON A GAME OBJECT THAT IS ACTIVE AND ONLY LOADS ONCE (SPLASH SCREEN)

    private SOAPStoreManager store_manager_script;

	// Use this for initialization
	void Start () 
    {
        // TODO: comment out initialization and put on splash screen
        SoomlaStore.Initialize(new SOAPStoreAssets());

        // These event catchers need to be on a gameobject that is never turned off, never destroyed, and only loads once
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
        GameObject temp_1 = GameObject.Find("store_container");
        if (temp_1 != null) { store_manager_script = temp_1.GetComponent<SOAPStoreManager>(); }

        store_manager_script.setCoinText();
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
