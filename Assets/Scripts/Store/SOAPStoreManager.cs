﻿using UnityEngine;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;
using UnityEngine.UI;

public class SOAPStoreManager : MonoBehaviour {

    // TODO: MAKE SURE TO RESET ITEM BALANCES TO ZERO BEFORE PUBLISH
    public Button coin_buy_button;
    public Button money_buy_button;
    public GameObject avatar_purchase_info;
    public GameObject reward_description_go;
    public Text store_coin_text;
    public Text game_over_coin_text;
    public Text pause_coin_text;
    public AvatarTailSwap avatar_swap_script;
    private string avatar_item_id;


	// Use this for initialization
	void Start () 
    {
        // For testing coin purchases
        StoreInventory.GiveItem(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID, 50000);
        //StoreInventory.TakeItem(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID, 130000);
	}

	// Update is called once per frame
	void Update () 
    {
        
	}


    // Change the store currency text (called by SOAPStoreEvents)
    public void setStoreCoinText()
    {
        store_coin_text.text = "" + StoreInventory.GetItemBalance(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID);
        //Debug.Log(string.Format("The coin balance is: {0}", "$ " + StoreInventory.GetItemBalance(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID)));
    }

    public void setGameOverCoinText()
    {
        game_over_coin_text.text = "" + StoreInventory.GetItemBalance(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID);
        //Debug.Log(string.Format("The coin balance is: {0}", "$ " + StoreInventory.GetItemBalance(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID)));
    }

    public void setPauseCoinText()
    {
        pause_coin_text.text = "" + StoreInventory.GetItemBalance(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID);
        //Debug.Log(string.Format("The coin balance is: {0}", "$ " + StoreInventory.GetItemBalance(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID)));
    }
    


    // Set by the grid snap script
    public void setAvatarID(string item_id)
    {
        avatar_item_id = item_id;
    }


    // Get the virtual and real money cost of the item
    public string[] getPrices(string item_id)
    {
        string[] price_list = new string[2];

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


    // Update the store button prices
    public void updatePrices(string item_id)
    {
        // Default avatars and tails
        if (item_id == "default_avatar" || item_id == "default_tail" || item_id == "orange_avatar" || item_id == "orange_tail")
        {
            coin_buy_button.gameObject.SetActive(false);
            money_buy_button.gameObject.SetActive(false);
            avatar_purchase_info.SetActive(true);
            reward_description_go.SetActive(false);
        }

        // Check balance of reward avatar
        else if (RewardedAvatars.avatar_balance_index_map.ContainsKey(item_id))
        {
            coin_buy_button.gameObject.SetActive(false);
            money_buy_button.gameObject.SetActive(false);

            if (RewardedAvatars.isAvatarUnlocked(item_id))
            {
                avatar_purchase_info.SetActive(true);
                reward_description_go.SetActive(false);
            }
            else
            {
                avatar_purchase_info.SetActive(false);
                reward_description_go.SetActive(true);
                reward_description_go.GetComponent<Text>().text = RewardedAvatars.avatar_earn_text_map[item_id];
            }
        }

        // For all other avatars update the prices
        else
        {
            string[] price_list = getPrices(item_id);
            coin_buy_button.GetComponentInChildren<Text>().text = price_list[0];
            money_buy_button.GetComponentInChildren<Text>().text = "$" + price_list[1];

            bool can_afford = StoreInventory.CanAfford(item_id);

            // If user cannot afford disable the coin buy button
            if (can_afford) { coin_buy_button.enabled = true; }
            else { coin_buy_button.enabled = false; }

            // If user already bought don't show the buy buttons
            if (StoreInventory.GetItemBalance(item_id) == 1 || StoreInventory.GetItemBalance("soap_" + item_id) == 1)
            {
                coin_buy_button.gameObject.SetActive(false);
                money_buy_button.gameObject.SetActive(false);
                reward_description_go.SetActive(false);
                avatar_purchase_info.SetActive(true);
            }
            else
            {
                coin_buy_button.gameObject.SetActive(true);
                money_buy_button.gameObject.SetActive(true);
                reward_description_go.SetActive(false);
                avatar_purchase_info.SetActive(false);
            }
        }
    }


    // Give player coins
    public void giveCoins()
    {
        StoreInventory.GiveItem(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID, 5);
    }

	// Give player coins
    public void challengeCoins()
    {
        StoreInventory.GiveItem(SOAPStoreAssets.SOAP_CURRENCY_ITEM_ID, 100);
    }

    public void buyAvatarWithCoin()
    {
        StoreInventory.BuyItem(avatar_item_id);
        updatePrices(avatar_item_id);
        // When an avatar is bought automatically select it
        avatar_swap_script.setAvatar(avatar_item_id);
        Debug.Log(string.Format("Just bought a new avatar with coins: {0}", avatar_item_id));
    }


    public void buyAvatarWithMoney()
    {
        StoreInventory.BuyItem("soap_" + avatar_item_id);
        updatePrices(avatar_item_id);
        // When an avatar is bought automatically select it
        avatar_swap_script.setAvatar(avatar_item_id);
        Debug.Log(string.Format("Just bought a new avatar with money: {0}", avatar_item_id));
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
//Facebook username: redtapestudiosinc@gmail.com 7<DbP4yP