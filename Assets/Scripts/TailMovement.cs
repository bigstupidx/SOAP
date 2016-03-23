using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TailMovement : MonoBehaviour {

    List<GameObject> tail_elements = new List<GameObject>();    // Used to reorder tails to mimic snake movement
    public GameObject[] tail_sprites;   // Tail sprites to set active when a grow element has been eaten
    public bool grow_tail = false;  // True if the avatar has eaten a grow element since the last minimum distance covered
    private int tail_count = 0;     // The amount of tails collected. Used to access tail elements in tail_sprites array

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    // Place the last tail in the gap created when the avatar moves the minimum distance (specified in AvatarController)
    public void tailFollow(Vector3 position)
    {
        if (grow_tail)
        {
            GameObject tail = tail_sprites[tail_count];
            tail.SetActive(true);
            tail_elements.Insert(0, tail);
            tail.transform.position = position;
            grow_tail = false;
            tail_count++;

            //foreach (GameObject obj in tail_elements)
            //{
            //    Debug.Log(obj.name);
            //}
        }

        else if (tail_elements.Count != 0)
        {
            int last_index = tail_elements.Count - 1;
            GameObject last_tail = tail_elements[last_index];
            last_tail.transform.position = position;
            tail_elements.RemoveAt(last_index);
            tail_elements.Insert(0, last_tail);

            //foreach (GameObject obj in tail_elements)
            //{
            //    Debug.Log(obj.name);
            //}
        }
    }
}
