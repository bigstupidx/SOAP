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
        return new VirtualGood[] { NO_ADS_LTVG, SNAKE_AVATAR_C, SNAKE_AVATAR_M, HADOKEN_AVATAR_C, HADOKEN_AVATAR_M, 
                                    YOSHI_AVATAR_C, YOSHI_AVATAR_M, NINJA_TAIL_C, NINJA_TAIL_M, SKULL_TAIL_C, SKULL_TAIL_M,
                                    CAT_TAIL_M, CAT_TAIL_C,
                                };
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

    public const string SNAKE_AVATAR_ITEM_ID = "snake_avatar";
    public const string SNAKE_AVATAR_PRODUCT_ID = "soap_snake_avatar";

    public const string HADOKEN_AVATAR_ITEM_ID = "hadoken_avatar";
    public const string HADOKEN_AVATAR_PRODUCT_ID = "soap_hadoken_avatar";

    public const string YOSHI_AVATAR_ITEM_ID = "yoshi_avatar";
    public const string YOSHI_AVATAR_PRODUCT_ID = "soap_yoshi_avatar";

    public const string NINJA_TAIL_ITEM_ID = "ninja_tail";
    public const string NINJA_TAIL_PRODUCT_ID = "soap_ninja_tail";

    public const string SKULL_TAIL_ITEM_ID = "skull_tail";
    public const string SKULL_TAIL_PRODUCT_ID = "soap_skull_tail";

    public const string CAT_TAIL_ITEM_ID = "cat_tail";
    public const string CAT_TAIL_PRODUCT_ID = "soap_cat_tail";

    public const string NO_ADS_LIFETIME_PRODUCT_ID = "soap_no_ads";

    /** Virtual Currencies **/

    public static VirtualCurrency SOAP_CURRENCY = new VirtualCurrency(
                "Coins",										// name
                "SOAP Currency",								// description
                SOAP_CURRENCY_ITEM_ID							// item id
    );


    /** LifeTimeVGs - can only be purchased once and lasts forever **/

    // Purchase snake with virtual currency
    public static VirtualGood SNAKE_AVATAR_C = new LifetimeVG(
        "Snake", 													    // name
        "Unlock Snake Avatar",				 							// description
        SNAKE_AVATAR_ITEM_ID,										    // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 5000)	    // the way this virtual good is purchased
    );

    // Purchase snake with real money
    public static VirtualGood SNAKE_AVATAR_M = new LifetimeVG(
        "Snake", 													    // name
        "Unlock Snake Avatar",				 							// description
        SNAKE_AVATAR_PRODUCT_ID,										// product id
        new PurchaseWithMarket(SNAKE_AVATAR_PRODUCT_ID, 0.99)	        // the way this virtual good is purchased
    );

    // Purchase hadoken with virtual currency
    public static VirtualGood HADOKEN_AVATAR_C = new LifetimeVG(
        "Hadoken", 												    	// name
        "Unlock Hadoken Avatar",				 						// description
        HADOKEN_AVATAR_ITEM_ID,										    // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 10000)	    // the way this virtual good is purchased
    );

    // Purchase hadoken with real money
    public static VirtualGood HADOKEN_AVATAR_M = new LifetimeVG(
        "Hadoken", 													    // name
        "Unlock Hadoken Avatar",				 						// description
        HADOKEN_AVATAR_PRODUCT_ID,										// product id
        new PurchaseWithMarket(HADOKEN_AVATAR_PRODUCT_ID, 2.49)	        // the way this virtual good is purchased
    );

    // Purchase yoshi with virtual currency
    public static VirtualGood YOSHI_AVATAR_C = new LifetimeVG(
        "Yoshi", 												    	// name
        "Unlock yoshi Avatar",				 						    // description
        YOSHI_AVATAR_ITEM_ID,										    // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 8500)	    // the way this virtual good is purchased
    );

    // Purchase yoshi with real money
    public static VirtualGood YOSHI_AVATAR_M = new LifetimeVG(
        "Yoshi", 													    // name
        "Unlock yoshi Avatar",	    			 						// description
        YOSHI_AVATAR_PRODUCT_ID,										// product id
        new PurchaseWithMarket(YOSHI_AVATAR_PRODUCT_ID, 1.78)	        // the way this virtual good is purchased
    );

    // Purchase ninja with virtual currency
    public static VirtualGood NINJA_TAIL_C = new LifetimeVG(
        "Ninja", 													    // name
        "Unlock Ninja Tail",				 							// description
        NINJA_TAIL_ITEM_ID,										        // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 1345)	    // the way this virtual good is purchased
    );

    // Purchase ninja with real money
    public static VirtualGood NINJA_TAIL_M = new LifetimeVG(
        "Ninja", 													    // name
        "Unlock Ninja Tail",				 							// description
        NINJA_TAIL_PRODUCT_ID,										    // product id
        new PurchaseWithMarket(NINJA_TAIL_PRODUCT_ID, 0.50)	            // the way this virtual good is purchased
    );

    // Purchase ninja with virtual currency
    public static VirtualGood SKULL_TAIL_C = new LifetimeVG(
        "Skull", 													    // name
        "Unlock Skull Tail",				 							// description
        SKULL_TAIL_ITEM_ID,										        // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 2984)	    // the way this virtual good is purchased
    );

    // Purchase skull with real money
    public static VirtualGood SKULL_TAIL_M = new LifetimeVG(
        "Skull", 													    // name
        "Unlock Skull Tail",				 							// description
        SKULL_TAIL_PRODUCT_ID,										    // product id
        new PurchaseWithMarket(SKULL_TAIL_PRODUCT_ID, 0.25)	            // the way this virtual good is purchased
    );

    // Purchase cat with virtual currency
    public static VirtualGood CAT_TAIL_C = new LifetimeVG(
        "Cat", 													    // name
        "Unlock Cat Tail",				 							// description
        CAT_TAIL_ITEM_ID,										        // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 3988)	    // the way this virtual good is purchased
    );

    // Purchase cat with real money
    public static VirtualGood CAT_TAIL_M = new LifetimeVG(
        "Cat", 													    // name
        "Unlock Cat Tail",				 							// description
        CAT_TAIL_PRODUCT_ID,										    // product id
        new PurchaseWithMarket(CAT_TAIL_PRODUCT_ID, 0.85)	            // the way this virtual good is purchased
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
        new List<string>(new string[] { SNAKE_AVATAR_ITEM_ID })
    );

}