using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class gridsnap : MonoBehaviour {
    GridLayoutGroup grid;
    RectTransform rect;
    ScrollRect scrollRect;

    Vector2 targetPos;
    bool done = false;
    float t = 0;

    public Text avatar_name_txt;
    public Text avatar_type_txt;

    private string avatar_name;
    private SOAPStoreManager store_manager_script;
    private string previous_avatar_name = "";
    private AvatarTailSwap avatar_swap_script; 



    void Start() {
        grid = GetComponent<GridLayoutGroup>();
        rect = GetComponent<RectTransform>();
        scrollRect = GetComponentInParent<ScrollRect>();

        GameObject temp_1 = GameObject.Find("store_ui_gr");
        if (temp_1 != null) { store_manager_script = temp_1.GetComponent<SOAPStoreManager>(); }

        GameObject temp_2 = GameObject.Find("avatar_swap_script");
        if (temp_2 != null) { avatar_swap_script = temp_2.GetComponent<AvatarTailSwap>(); }

        // auto adjust the width of the grid to have space for all the childs
        //rect.sizeDelta = new Vector2((transform.childCount + 2f) * grid.cellSize.x + (transform.childCount - 1f) * grid.spacing.x, rect.sizeDelta.y);
        rect.sizeDelta = new Vector2((transform.childCount + 5f) * grid.cellSize.x + (transform.childCount - 0f) * grid.spacing.x, rect.sizeDelta.y);
    }

    public void Update() {
        t = Time.deltaTime * 15f;
        if (t > 1f) {
            t = 1f;
        }
        if (Mathf.Abs(scrollRect.velocity.x) > 800f && !done) {
            touchUp();
        }
        if (!done && Mathf.Abs(scrollRect.velocity.x) < 800f) {
            rect.localPosition = Vector2.Lerp(rect.localPosition, targetPos, t);
            if (Vector3.Distance(rect.localPosition, targetPos) < 0.001f) {
                rect.localPosition = targetPos;
                done = true;
            }
        }

        Vector2 tempPos = new Vector2(Mathf.Round(rect.localPosition.x / (grid.cellSize.x + grid.spacing.x)) * (grid.cellSize.x + grid.spacing.x) * -1f, 0);
        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            if (child.localPosition.x == tempPos.x) {
                
                // Scale the middle avatar
                child.localScale = Vector3.Lerp(child.localScale, new Vector3(1.4f, 1.4f, 1f), t);
                
                avatar_name = child.name;

                // Update the button prices and the avatar name and type texts
                if (previous_avatar_name != avatar_name)
                {
                    previous_avatar_name = avatar_name;

                    // Only updates prices if the avatar and tail are purchasable
                    store_manager_script.updatePrices(avatar_name);
                    store_manager_script.setAvatarID(avatar_name);

                    //if (avatar_name != "default_avatar" && avatar_name != "default_tail")
                    //{
                    //    store_manager_script.updatePrices(avatar_name);
                    //    store_manager_script.setAvatarID(avatar_name);
                    //}

                    string[] avatar_name_list = getAvatarNameAndType(avatar_name);
                    avatar_name_txt.text = avatar_name_list[0];
                    avatar_type_txt.text = avatar_name_list[1];

                    avatar_swap_script.setAvatar(avatar_name);
                }
            }
            else {
                child.localScale = Vector3.Lerp(child.localScale, new Vector3(1f, 1f, 1f), t);
            }
        }
    }


    // Get the name and type of the middle avatar
    public string[] getAvatarNameAndType(string name)
    {
        string[] name_list = new string[2];
        name_list[0] = name.Split(new string[] { "_" }, StringSplitOptions.None)[0].ToUpper();
        name_list[1] = name.Split(new string[] { "_" }, StringSplitOptions.None)[1].ToUpper();
        //Debug.Log(string.Format("Avatar name is: {0}\nAvatar type is: {1}", name_list[0], name_list[1]));
        return name_list;
    }

    public void touchDown() {
        done = true;
    }

    public void touchUp() {
        float newX = Mathf.Round(rect.localPosition.x / (grid.cellSize.x + grid.spacing.x)) * (grid.cellSize.x + grid.spacing.x);
        newX = Mathf.Sign(newX) * Mathf.Min(Mathf.Abs(newX), (rect.rect.width - scrollRect.GetComponent<RectTransform>().rect.width) / 2f);
        targetPos = new Vector2(newX, 0);
        done = false;
    }
}