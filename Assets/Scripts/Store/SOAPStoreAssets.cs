using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;

public class SOAPStoreAssets : IStoreAssets {

    /// You need to bump the version after ANY change in <c>IStoreAssets</c> for the local
    /// database to realize it needs to refresh its data.
    /// </summary>
    /// <returns>the version of your specific <c>IStoreAssets</c>.</returns>
    public int GetVersion()
    {
        return 1;
    }

    /// <summary>
    /// Retrieves the array of your game's virtual currencies.
    /// </summary>
    /// <returns>All virtual currencies in your game.</returns>
    public VirtualCurrency[] GetCurrencies()
    {
        return new VirtualCurrency[] { SOAP_CURRENCY };
    }

    /// <summary>
    /// Retrieves the array of all virtual goods served by your store (all kinds in one array).
    /// </summary>
    /// <returns>All virtual goods in your game.</returns>
    public VirtualGood[] GetGoods()
    {
        return new VirtualGood[] { NO_ADS_LTVG, AVATAR_NAME_1_M, AVATAR_NAME_1_C };
    }

    /// <summary>
    /// Retrieves the array of all virtual currency packs served by your store.
    /// </summary>
    /// <returns>All virtual currency packs in your game.</returns>
    public VirtualCurrencyPack[] GetCurrencyPacks()
    {
        return new VirtualCurrencyPack[] { };
    }

    /// <summary>
    /// Retrieves the array of all virtual categories handled in your store.
    /// </summary>
    /// <returns>All virtual categories in your game.</returns>
    public VirtualCategory[] GetCategories()
    {
        return new VirtualCategory[] { GENERAL_CATEGORY };
    }


    /** Static Final Members **/

    public const string SOAP_CURRENCY_ITEM_ID = "soap_coins";

    public const string AVATAR_NAME_1_ITEM_ID = "generic_avatar_1";
    public const string AVATAR_NAME_1_PRODUCT_ID = "soap_generic_avatar_1";

    public const string NO_ADS_LIFETIME_PRODUCT_ID = "soap_no_ads";

    /** Virtual Currencies **/

    public static VirtualCurrency SOAP_CURRENCY = new VirtualCurrency(
                "Coins",										// name
                "SOAP Currency",								// description
                SOAP_CURRENCY_ITEM_ID							// item id
    );


    /** LifeTimeVGs - can only be purchased once and lasts forever **/

    // Purchase avatar 1 with virtual currency
    public static VirtualGood AVATAR_NAME_1_C = new LifetimeVG(
        "Avatar 1", 													// name
        "Unlock Avatar 1",				 								// description
        AVATAR_NAME_1_ITEM_ID,										    // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 5000)	    // the way this virtual good is purchased
    );

    // Purchase avatar 1 with real money
    public static VirtualGood AVATAR_NAME_1_M = new LifetimeVG(
        "Avatar 1", 													// name
        "Unlock Avatar 1",				 								// description
        AVATAR_NAME_1_PRODUCT_ID,										// product id
        new PurchaseWithMarket(AVATAR_NAME_1_PRODUCT_ID, 0.99)	        // the way this virtual good is purchased
    );

    // Remove all ads from the game
    public static VirtualGood NO_ADS_LTVG = new LifetimeVG(
		"No Ads", 														// name
		"No More Ads!",				 									// description
        NO_ADS_LIFETIME_PRODUCT_ID,										// item id
		new PurchaseWithMarket(NO_ADS_LIFETIME_PRODUCT_ID, 1.99)	    // the way this virtual good is purchased
    );


    /** Virtual Categories **/

    public static VirtualCategory GENERAL_CATEGORY = new VirtualCategory(
        "General",
        new List<string>(new string[] { AVATAR_NAME_1_ITEM_ID })
    );

}