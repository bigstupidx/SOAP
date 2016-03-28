﻿using UnityEngine;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;

public class MayhemStoreManager : MonoBehaviour {

    // TODO: MAKE SURE TO RESET ITEM BALANCES TO ZERO BEFORE PUBLISH
    // TODO: PUT THIS CLASS ON A GAME OBJECT THAT IS ACTIVE AND ONLY LOADS ONCE (SPLASH SCREEN)

	// Use this for initialization
	void Start () 
    {
        // SoomlaStore.Initialize(new MayhemStoreAssets());
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

    //void onEnable()
    //{
    //    Time.timeScale = 0;
    //}


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


    public void buySlowTimerPack()
    {
        StoreInventory.BuyItem(MayhemStoreAssets.SLOW_TIMER_FIVE_PACK_PRODUCT_ID);   
    }


    public void buySlowTimer()
    {
        bool can_afford = StoreInventory.CanAfford(MayhemStoreAssets.SLOW_TIMER_ITEM_ID);

        if (can_afford)
        {
            StoreInventory.BuyItem(MayhemStoreAssets.SLOW_TIMER_ITEM_ID);
        }

        else
        {
            Debug.Log("You don't have enough coins to afford slow timer item!");
        }
    }


    public void buyIncreaseSliderPack()
    {
        StoreInventory.BuyItem(MayhemStoreAssets.INCREASE_SLIDER_FIVE_PACK_PRODUCT_ID);
    }


    public void buyIncreaseSlider()
    {
        bool can_afford = StoreInventory.CanAfford(MayhemStoreAssets.INCREASE_SLIDER_ITEM_ID);

        if (can_afford)
        {
            StoreInventory.BuyItem(MayhemStoreAssets.INCREASE_SLIDER_ITEM_ID);
        }

        else
        {
            Debug.Log("You don't have enough coins to afford increase slider item!");
        }

    }


    public void buyReduceShapePack()
    {
        StoreInventory.BuyItem(MayhemStoreAssets.REDUCE_SHAPE_FIVE_PACK_PRODUCT_ID);
    }


    public void buyReduceShape()
    {
        bool can_afford = StoreInventory.CanAfford(MayhemStoreAssets.REDUCE_SHAPE_ITEM_ID);

        if (can_afford)
        {
            StoreInventory.BuyItem(MayhemStoreAssets.REDUCE_SHAPE_ITEM_ID);
        }

        else
        {
            Debug.Log("You don't have enough coins to afford reduce shape item!");
        }

    }

    
    public void buyDoublePointPack()
    {
        StoreInventory.BuyItem(MayhemStoreAssets.DOUBLE_POINT_FIVE_PACK_PRODUCT_ID);
    }


    public void buyDoublePoint()
    {
        bool can_afford = StoreInventory.CanAfford(MayhemStoreAssets.DOUBLE_POINT_ITEM_ID);

        if (can_afford)
        {
            StoreInventory.BuyItem(MayhemStoreAssets.DOUBLE_POINT_ITEM_ID);
        }

        else
        {
            Debug.Log("You don't have enough coins to afford double points item!");
        }

    }


    public void buyWinterTheme()
    {
        StoreInventory.BuyItem(MayhemStoreAssets.WINTER_THEME_LIFETIME_PRODUCT_ID);
    }


    public void buyRemoveAds()
    {
        StoreInventory.BuyItem(MayhemStoreAssets.NO_ADS_LIFETIME_PRODUCT_ID);
    }


    public void restorePurchases()
    {
        Debug.Log("Restoring previous purchases!");
        SoomlaStore.RestoreTransactions();
    }
}
//Soomla secret: X5rl73jZ8xD86GEabD7Lh3Dm4LBeQG7v
//Keystore pwd: t@R3p3D&uO
//Twitter username: redtapestudios pwd: Apestudios11