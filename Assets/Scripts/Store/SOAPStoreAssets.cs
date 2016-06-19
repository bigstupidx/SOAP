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
        return new VirtualGood[] {  NO_ADS_LTVG, NINJA_AVATAR_C, NINJA_AVATAR_M, SKULL_AVATAR_C, SKULL_AVATAR_M, 
                                    CAT_AVATAR_C, CAT_AVATAR_M,ALIEN_AVATAR_C, ALIEN_AVATAR_M, RANGER_AVATAR_C, RANGER_AVATAR_M,
                                    MUMMY_AVATAR_C, MUMMY_AVATAR_M, MONSTER_AVATAR_C, MONSTER_AVATAR_M, GHOST_AVATAR_C, GHOST_AVATAR_M,
                                    NINJA_TAIL_C, NINJA_TAIL_M, SKULL_TAIL_C, SKULL_TAIL_M, CAT_TAIL_M, CAT_TAIL_C, ALIEN_TAIL_C,
                                    ALIEN_TAIL_M, RANGER_TAIL_C, RANGER_TAIL_M, MUMMY_TAIL_C, MUMMY_TAIL_M, MONSTER_TAIL_C,
                                    MONSTER_TAIL_M, GHOST_TAIL_C, GHOST_TAIL_M,
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

    public const string NINJA_AVATAR_ITEM_ID = "ninja_avatar";
    public const string NINJA_AVATAR_PRODUCT_ID = "soap_ninja_avatar";

    public const string SKULL_AVATAR_ITEM_ID = "skull_avatar";
    public const string SKULL_AVATAR_PRODUCT_ID = "soap_skull_avatar";

    public const string CAT_AVATAR_ITEM_ID = "cat_avatar";
    public const string CAT_AVATAR_PRODUCT_ID = "soap_cat_avatar";

    public const string ALIEN_AVATAR_ITEM_ID = "alien_avatar";
    public const string ALIEN_AVATAR_PRODUCT_ID = "soap_alien_avatar";

    public const string MUMMY_AVATAR_ITEM_ID = "mummy_avatar";
    public const string MUMMY_AVATAR_PRODUCT_ID = "soap_mummy_avatar";

    public const string MONSTER_AVATAR_ITEM_ID = "monster_avatar";
    public const string MONSTER_AVATAR_PRODUCT_ID = "soap_monster_avatar";

    public const string RANGER_AVATAR_ITEM_ID = "ranger_avatar";
    public const string RANGER_AVATAR_PRODUCT_ID = "soap_ranger_avatar";

    public const string GHOST_AVATAR_ITEM_ID = "ghost_avatar";
    public const string GHOST_AVATAR_PRODUCT_ID = "soap_ghost_avatar";

    public const string NINJA_TAIL_ITEM_ID = "ninja_tail";
    public const string NINJA_TAIL_PRODUCT_ID = "soap_ninja_tail";

    public const string SKULL_TAIL_ITEM_ID = "skull_tail";
    public const string SKULL_TAIL_PRODUCT_ID = "soap_skull_tail";

    public const string CAT_TAIL_ITEM_ID = "cat_tail";
    public const string CAT_TAIL_PRODUCT_ID = "soap_cat_tail";

    public const string ALIEN_TAIL_ITEM_ID = "alien_tail";
    public const string ALIEN_TAIL_PRODUCT_ID = "soap_alien_tail";

    public const string RANGER_TAIL_ITEM_ID = "ranger_tail";
    public const string RANGER_TAIL_PRODUCT_ID = "soap_ranger_tail";

    public const string MUMMY_TAIL_ITEM_ID = "mummy_tail";
    public const string MUMMY_TAIL_PRODUCT_ID = "soap_mummy_tail";

    public const string MONSTER_TAIL_ITEM_ID = "monster_tail";
    public const string MONSTER_TAIL_PRODUCT_ID = "soap_monster_tail";

    public const string GHOST_TAIL_ITEM_ID = "ghost_tail";
    public const string GHOST_TAIL_PRODUCT_ID = "soap_ghost_tail";

    public const string NO_ADS_LIFETIME_PRODUCT_ID = "soap_no_ads";

    /** Virtual Currencies **/

    public static VirtualCurrency SOAP_CURRENCY = new VirtualCurrency(
                "Coins",										// name
                "SOAP Currency",								// description
                SOAP_CURRENCY_ITEM_ID							// item id
    );


    /** LifeTimeVGs - can only be purchased once and lasts forever **/

    // Purchase ninja with virtual currency
    public static VirtualGood NINJA_AVATAR_C = new LifetimeVG(
        "Ninja", 													    // name
        "Unlock Ninja Avatar",				 							// description
        NINJA_AVATAR_ITEM_ID,										    // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 5000)	    // the way this virtual good is purchased
    );

    // Purchase ninja with real money
    public static VirtualGood NINJA_AVATAR_M = new LifetimeVG(
        "Ninja", 													    // name
        "Unlock Ninja Avatar",				 							// description
        NINJA_AVATAR_PRODUCT_ID,										// product id
        new PurchaseWithMarket(NINJA_AVATAR_PRODUCT_ID, 0.99)	        // the way this virtual good is purchased
    );

    // Purchase skull with virtual currency
    public static VirtualGood SKULL_AVATAR_C = new LifetimeVG(
        "Skull", 												    	// name
        "Unlock Skull Avatar",				 						    // description
        SKULL_AVATAR_ITEM_ID,										    // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 10000)	    // the way this virtual good is purchased
    );

    // Purchase skull with real money
    public static VirtualGood SKULL_AVATAR_M = new LifetimeVG(
        "Skull", 													    // name
        "Unlock Skull Avatar",				 						    // description
        SKULL_AVATAR_PRODUCT_ID,										// product id
        new PurchaseWithMarket(SKULL_AVATAR_PRODUCT_ID, 2.49)	        // the way this virtual good is purchased
    );

    // Purchase cat with virtual currency
    public static VirtualGood CAT_AVATAR_C = new LifetimeVG(
        "Cat", 												    	    // name
        "Unlock Cat Avatar",				 						    // description
        CAT_AVATAR_ITEM_ID,										        // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 8500)	    // the way this virtual good is purchased
    );

    // Purchase cat with real money
    public static VirtualGood CAT_AVATAR_M = new LifetimeVG(
        "Cat", 													        // name
        "Unlock Cat Avatar",	    			 						// description
        CAT_AVATAR_PRODUCT_ID,										    // product id
        new PurchaseWithMarket(CAT_AVATAR_PRODUCT_ID, 1.78)	            // the way this virtual good is purchased
    );

    // Purchase alien with virtual currency
    public static VirtualGood ALIEN_AVATAR_C = new LifetimeVG(
        "Alien", 											     // name
        "Unlock Alien Avatar",				 				     // description
        ALIEN_AVATAR_ITEM_ID,								     // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 5000) // the way this virtual good is purchased
    );
    
    // Purchase alien with real money
    public static VirtualGood ALIEN_AVATAR_M = new LifetimeVG(
        "Alien", 													// name
        "Unlock Alien Avatar",				 						// description
        ALIEN_AVATAR_PRODUCT_ID,									// product id
    new PurchaseWithMarket(ALIEN_AVATAR_PRODUCT_ID, 0.99)	    // the way this virtual good is purchased
    );

    // Purchase mummy with virtual currency
    public static VirtualGood MUMMY_AVATAR_C = new LifetimeVG(
        "Mummy", 											     // name
        "Unlock Mummy Avatar",				 				     // description
        MUMMY_AVATAR_ITEM_ID,								     // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 5000) // the way this virtual good is purchased
    );
    
    // Purchase mummy with real money
    public static VirtualGood MUMMY_AVATAR_M = new LifetimeVG(
        "Mummy", 													// name
        "Unlock Mummy Avatar",				 						// description
        MUMMY_AVATAR_PRODUCT_ID,									// product id
        new PurchaseWithMarket(MUMMY_AVATAR_PRODUCT_ID, 0.99)	    // the way this virtual good is purchased
    );

    // Purchase monster with virtual currency
    public static VirtualGood MONSTER_AVATAR_C = new LifetimeVG(
        "Monster", 											     // name
        "Unlock Monster Avatar",				 				     // description
        MONSTER_AVATAR_ITEM_ID,								     // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 5000) // the way this virtual good is purchased
    );
    
    // Purchase monster with real money
        public static VirtualGood MONSTER_AVATAR_M = new LifetimeVG(
        "Monster", 													// name
        "Unlock Monster Avatar",				 						// description
        MONSTER_AVATAR_PRODUCT_ID,									// product id
        new PurchaseWithMarket(MONSTER_AVATAR_PRODUCT_ID, 0.99)	    // the way this virtual good is purchased
    );

    // Purchase ranger with virtual currency
    public static VirtualGood RANGER_AVATAR_C = new LifetimeVG(
        "Ranger", 											     // name
        "Unlock Ranger Avatar",				 				     // description
        RANGER_AVATAR_ITEM_ID,								     // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 5000) // the way this virtual good is purchased
    );

    // Purchase ranger with real money
    public static VirtualGood RANGER_AVATAR_M = new LifetimeVG(
        "Ranger", 													// name
        "Unlock Ranger Avatar",				 						// description
        RANGER_AVATAR_PRODUCT_ID,									// product id
        new PurchaseWithMarket(RANGER_AVATAR_PRODUCT_ID, 0.99)	    // the way this virtual good is purchased
    );

    // Purchase ghost with virtual currency
    public static VirtualGood GHOST_AVATAR_C = new LifetimeVG(
        "Ghost", 											     // name
        "Unlock Ghost Avatar",				 				     // description
        GHOST_AVATAR_ITEM_ID,								     // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 5000) // the way this virtual good is purchased
    );

    // Purchase ghost with real money
    public static VirtualGood GHOST_AVATAR_M = new LifetimeVG(
        "Ghost", 													// name
        "Unlock Ghost Avatar",				 						// description
        GHOST_AVATAR_PRODUCT_ID,									// product id
        new PurchaseWithMarket(GHOST_AVATAR_PRODUCT_ID, 0.99)	    // the way this virtual good is purchased
    );



    // --
    // -- Set up tail purchases --
    // --

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
        "Cat", 													        // name
        "Unlock Cat Tail",				 							    // description
        CAT_TAIL_ITEM_ID,										        // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 3988)	    // the way this virtual good is purchased
    );

    // Purchase cat with real money
    public static VirtualGood CAT_TAIL_M = new LifetimeVG(
        "Cat", 													        // name
        "Unlock Cat Tail",				 							    // description
        CAT_TAIL_PRODUCT_ID,										    // product id
        new PurchaseWithMarket(CAT_TAIL_PRODUCT_ID, 0.85)	            // the way this virtual good is purchased
    );

    // Purchase alien with virtual currency
    public static VirtualGood ALIEN_TAIL_C = new LifetimeVG(
        "Alien", 													    // name
        "Unlock Alien Tail",				 							// description
        ALIEN_TAIL_ITEM_ID,										        // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 1345)	    // the way this virtual good is purchased
    );

    // Purchase alien with real money
    public static VirtualGood ALIEN_TAIL_M = new LifetimeVG(
        "Alien", 													    // name
        "Unlock Alien Tail",				 							// description
        ALIEN_TAIL_PRODUCT_ID,										    // product id
        new PurchaseWithMarket(ALIEN_TAIL_PRODUCT_ID, 0.50)	            // the way this virtual good is purchased
    );


    // Purchase ranger with virtual currency
    public static VirtualGood RANGER_TAIL_C = new LifetimeVG(
        "Ranger", 													    // name
        "Unlock Ranger Tail",				 							// description
        RANGER_TAIL_ITEM_ID,										    // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 1345)	    // the way this virtual good is purchased
    );

    // Purchase ranger with real money
    public static VirtualGood RANGER_TAIL_M = new LifetimeVG(
        "Ranger", 													    // name
        "Unlock Ranger Tail",				 							// description
        RANGER_TAIL_PRODUCT_ID,										    // product id
        new PurchaseWithMarket(RANGER_TAIL_PRODUCT_ID, 0.50)	        // the way this virtual good is purchased
    );

    // Purchase mummy with virtual currency
    public static VirtualGood MUMMY_TAIL_C = new LifetimeVG(
        "Mummy", 													    // name
        "Unlock Mummy Tail",				 							// description
        MUMMY_TAIL_ITEM_ID,										        // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 1345)	    // the way this virtual good is purchased
    );

    // Purchase mummy with real money
    public static VirtualGood MUMMY_TAIL_M = new LifetimeVG(
        "Mummy", 													    // name
        "Unlock Mummy Tail",				 							// description
        MUMMY_TAIL_PRODUCT_ID,										    // product id
        new PurchaseWithMarket(MUMMY_TAIL_PRODUCT_ID, 0.50)	            // the way this virtual good is purchased
    );


    // Purchase monster with virtual currency
    public static VirtualGood MONSTER_TAIL_C = new LifetimeVG(
        "Monster", 													    // name
        "Unlock Monster Tail",				 							// description
        MONSTER_TAIL_ITEM_ID,										    // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 1345)	    // the way this virtual good is purchased
    );

    // Purchase monster with real money
    public static VirtualGood MONSTER_TAIL_M = new LifetimeVG(
        "Monster", 													    // name
        "Unlock Monster Tail",				 							// description
        MONSTER_TAIL_PRODUCT_ID,										// product id
        new PurchaseWithMarket(MONSTER_TAIL_PRODUCT_ID, 0.50)	        // the way this virtual good is purchased
    );


    // Purchase ghost with virtual currency
    public static VirtualGood GHOST_TAIL_C = new LifetimeVG(
        "Ghost", 													    // name
        "Unlock Ghost Tail",				 							// description
        GHOST_TAIL_ITEM_ID,										        // item id
        new PurchaseWithVirtualItem(SOAP_CURRENCY_ITEM_ID, 1345)	    // the way this virtual good is purchased
    );

    // Purchase ghost with real money
    public static VirtualGood GHOST_TAIL_M = new LifetimeVG(
        "Ghost", 													    // name
        "Unlock Ghost Tail",				 							// description
        GHOST_TAIL_PRODUCT_ID,										    // product id
        new PurchaseWithMarket(GHOST_TAIL_PRODUCT_ID, 0.50)	            // the way this virtual good is purchased
    );


    // --
    // -- Remove Ads from the game
    // --

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
        new List<string>(new string[] { NINJA_AVATAR_ITEM_ID })
    );

}