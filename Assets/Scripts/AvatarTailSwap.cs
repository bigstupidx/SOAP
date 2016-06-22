using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;
using UnityEngine.SceneManagement;



public class AvatarTailSwap : MonoBehaviour {


    public Sprite[] avatar_sprite_list;
    public Sprite[] tail_sprite_list;

    private SpriteRenderer avatar_sprite;
    private GameObject tail_grp;
    private List<SpriteRenderer> tail_sprite = new List<SpriteRenderer>();
    Dictionary<string, Sprite> avatar_name_to_sprite_name = new Dictionary<string, Sprite>();
    Dictionary<string, Sprite> tail_name_to_sprite_name = new Dictionary<string, Sprite>();

	// Use this for initialization
	void Start () 
    {
        bool avatar_key_exists = PlayerPrefs.HasKey("Avatar");
        bool tail_key_exists = PlayerPrefs.HasKey("Tail");

        if (!avatar_key_exists)
        {
            PlayerPrefs.SetString("Avatar", "default_avatar");
        }

        if (!tail_key_exists)
        {
            PlayerPrefs.SetString("Tail", "default_tail");
        }

        initialize_avatar_map();
        initialize_tail_map();

        DontDestroyOnLoad(this.gameObject);
	}

    
    // Update is called once per frame
    void Update()
    {

    }


    // 
    void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            refresh_sprites();
        }
    }


    public void refresh_sprites()
    {   
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject temp_1 = GameObject.Find("avatar_obj");
            if (temp_1 != null) { avatar_sprite = temp_1.GetComponent<SpriteRenderer>(); }

            tail_grp = GameObject.Find("tail_grp");

            setAvatarSprite();
            getTailSprites(tail_grp);
            setTailSprite();
        }
    }


    // Populate the tail sprite list with a list of the sprite components of the tails
    private void getTailSprites(GameObject tail_group)
    {
        int tail_count = tail_group.transform.childCount;

        foreach (Transform child in tail_group.transform)
        {
            tail_sprite.Add(child.GetComponent<SpriteRenderer>());
        }
    }


    // Set the avatar sprite to the selected avatar sprite
    public void setAvatarSprite()
    {
        string selected_avatar = getAvatar();

        if (avatar_sprite != null)
        {
            avatar_sprite.sprite = avatar_name_to_sprite_name[selected_avatar];
            Debug.Log(string.Format("Avatar sprite set to: {0}", selected_avatar));
        }
    }


    // Set the tail sprites to the selected tail sprite
    public void setTailSprite()
    {
        string selected_tail = getTail();
        Debug.Log(string.Format("Tail sprite set to: {0}", selected_tail));

        //tail_sprite.ForEach(item => Debug.Log(item));

        foreach(SpriteRenderer tail in tail_sprite)
        {
            if (tail != null)
            {
                tail.sprite = tail_name_to_sprite_name[selected_tail];
            }
        }
    }


    // Maps the gameobject name to its sprite for avatars
    public void initialize_avatar_map()
    {
        avatar_name_to_sprite_name.Add("cat_avatar", avatar_sprite_list[0]);
        avatar_name_to_sprite_name.Add("alien_avatar", avatar_sprite_list[1]);
        avatar_name_to_sprite_name.Add("ninja_avatar", avatar_sprite_list[2]);
        avatar_name_to_sprite_name.Add("mummy_avatar", avatar_sprite_list[3]);
        avatar_name_to_sprite_name.Add("monster_avatar", avatar_sprite_list[4]);
        avatar_name_to_sprite_name.Add("ranger_avatar", avatar_sprite_list[5]);
        avatar_name_to_sprite_name.Add("skull_avatar", avatar_sprite_list[6]);
        avatar_name_to_sprite_name.Add("ghost_avatar", avatar_sprite_list[7]);
        avatar_name_to_sprite_name.Add("default_avatar", avatar_sprite_list[8]);
    }


    // Maps the gameobject name to its sprite for tails
    public void initialize_tail_map()
    {
        tail_name_to_sprite_name.Add("cat_tail", tail_sprite_list[0]);
        tail_name_to_sprite_name.Add("alien_tail", tail_sprite_list[1]);
        tail_name_to_sprite_name.Add("ninja_tail", tail_sprite_list[2]);
        tail_name_to_sprite_name.Add("mummy_tail", tail_sprite_list[3]);
        tail_name_to_sprite_name.Add("monster_tail", tail_sprite_list[4]);
        tail_name_to_sprite_name.Add("ranger_tail", tail_sprite_list[5]);
        tail_name_to_sprite_name.Add("skull_tail", tail_sprite_list[6]);
        tail_name_to_sprite_name.Add("ghost_tail", tail_sprite_list[7]);
        tail_name_to_sprite_name.Add("default_tail", tail_sprite_list[8]);
    }


    //
    public string getAvatar()
    {
        return PlayerPrefs.GetString("Avatar");
    }


    // Set the avatar player pref to the name of the selected (middle) avatar game object in the store scroll
    public void setAvatar(string avatar_name)
    {
        PurchasableVirtualItem virtual_item = (PurchasableVirtualItem)StoreInfo.GetItemByItemId(avatar_name);
        PurchasableVirtualItem market_item = (PurchasableVirtualItem)StoreInfo.GetItemByItemId("soap_" + avatar_name);

        int virtual_item_balance = virtual_item.GetBalance();
        int market_item_balance = market_item.GetBalance();

        if (virtual_item_balance == 1 || market_item_balance == 1)
        {
            PlayerPrefs.SetString("Avatar", avatar_name);
            Debug.Log(string.Format("Avatar player pref set to: {0}", avatar_name));
        }
    }


    public string getTail()
    {
        return PlayerPrefs.GetString("Tail");
    }


    // Set the tail player pref to the name of the selected (middle) tail game object in the store scroll
    public void setTail(string tail_name)
    {
        PurchasableVirtualItem virtual_item = (PurchasableVirtualItem)StoreInfo.GetItemByItemId(tail_name);
        PurchasableVirtualItem market_item = (PurchasableVirtualItem)StoreInfo.GetItemByItemId("soap_" + tail_name);

        int virtual_item_balance = virtual_item.GetBalance();
        int market_item_balance = market_item.GetBalance();

        if (virtual_item_balance == 1 || market_item_balance == 1)
        {
            PlayerPrefs.SetString("Tail", tail_name);
            Debug.Log(string.Format("Tail player pref set to: {0}", tail_name));
        }
    }
}
