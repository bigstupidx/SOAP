using UnityEngine;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;
using UnityEngine.UI;

public class SOAPStoreManager : MonoBehaviour {

    // TODO: MAKE SURE TO RESET ITEM BALANCES TO ZERO BEFORE PUBLISH
    // TODO: PUT THIS CLASS ON A GAME OBJECT THAT IS ACTIVE AND ONLY LOADS ONCE (SPLASH SCREEN)

    public Button coin_buy_button;
    public Button money_buy_button;



	// Use this for initialization
	void Start () 
    {
        // TODO: comment out initialization and put on splash screen
        SoomlaStore.Initialize(new SOAPStoreAssets());
        // These events should be called on the splash screen!!
        // Test it out on sunday
        //problem was that store which had this script on it was turned off by default and only executed when 
        //the store was entered
        //meaning i wasn't catching the events being generated
        StoreEvents.OnItemPurchased += onItemPurchased;
        StoreEvents.OnGoodBalanceChanged += OnGoodBalanceChanged;
        StoreEvents.OnRestoreTransactionsStarted += OnRestoreTransactionsStarted;
        StoreEvents.OnRestoreTransactionsFinished += OnRestoreTransactionsFinished;
        DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	void Update () 
    {
        
	}


    // Change inventory balance on gamescreen when item purchased
    public void onItemPurchased(PurchasableVirtualItem pvi, string payload)
    {
        //PowerUpManager.changeBalanceText(pvi.ItemId);
    }


    // Change inventory balance when item balance changed (by clicking power-up button from gamescreen)
    public void OnGoodBalanceChanged(VirtualGood vg, int balance, int amountAdded)
    {
        //PowerUpManager.changeBalanceText(vg.ItemId);
    }


    // Print message saying transactions are being restored
    public void OnRestoreTransactionsStarted()
    {
        Debug.Log("The transactions are being restored.");
    }


    // Print message saying transactions are restored
    public void OnRestoreTransactionsFinished(bool success)
    {
        Debug.Log("The transactions are now restored.");
    }


    // Get the virtual and real money cost of the item
    public string[] getPrices(string item_id)
    {
        string[] price_list = new string[2];
        price_list[0] = "test";

        PurchasableVirtualItem virtual_item = (PurchasableVirtualItem)StoreInfo.GetItemByItemId(item_id);
        PurchasableVirtualItem market_item = (PurchasableVirtualItem)StoreInfo.GetItemByItemId("soap_" + item_id);
        
        // Get cost in coins
        PurchaseWithVirtualItem virtual_purchase = (PurchaseWithVirtualItem)virtual_item.PurchaseType;
        price_list[0] = virtual_purchase.Amount.ToString();

        // Get cost in real money
        PurchaseWithMarket market_purchase = (PurchaseWithMarket)market_item.PurchaseType;
        price_list[1] = market_purchase.MarketItem.Price.ToString();

        return price_list;
    }


    public void updatePrices(string item_id)
    {
        string[] price_list = getPrices(item_id);
        coin_buy_button.GetComponentInChildren<Text>().text = price_list[0];
        money_buy_button.GetComponentInChildren<Text>().text = price_list[1];
    }


    //public void buyAvatar1()
    //{
    //    StoreInventory.BuyItem(SOAPStoreAssets.AVATAR_NAME_1_PRODUCT_ID);   
    //}




    public void buyAvatar1()
    {
        //bool can_afford = StoreInventory.CanAfford(SOAPStoreAssets.AVATAR_NAME_1_ITEM_ID);
        //Debug.Log(can_afford);

        //string itemId = SOAPStoreAssets.AVATAR_NAME_1_ITEM_ID;
        //double result = 0.0;

        //PurchasableVirtualItem item = (PurchasableVirtualItem)StoreInfo.GetItemByItemId(itemId);
        //if( item.PurchaseType.GetType() == typeof(PurchaseWithVirtualItem) ){
        //    PurchaseWithVirtualItem purchaseType = (PurchaseWithVirtualItem)item.PurchaseType;
        //    result = purchaseType.Amount;
        //}
        //else {
        //    PurchaseWithMarket purchaseType = (PurchaseWithMarket)item.PurchaseType;
        //    result = purchaseType.MarketItem.Price;
        //}

        //coin_buy_button.GetComponentInChildren<Text>().text = result.ToString();

        //Debug.Log(">>>>>>>>>>>>>>" + result);
    }


    public void buyRemoveAds()
    {
        StoreInventory.BuyItem(SOAPStoreAssets.NO_ADS_LIFETIME_PRODUCT_ID);
    }


    public void restorePurchases()
    {
        Debug.Log("Restoring previous purchases!");
        SoomlaStore.RestoreTransactions();
    }
}
//Soomla secret: IzE0it1qa49Dh4IUV16216yi1840Nz96
//Keystore pwd: t@R3p3D&uO
//Twitter username: redtapestudios pwd: Apestudios11