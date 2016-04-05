using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    public TailMovement tail_movement_script;

    // Perform specific action whenever player collider enters an objects trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Collect Tail
        if (other.gameObject.tag == "grow")
        {
            other.gameObject.SetActive(false);
            tail_movement_script.grow_tail = true;
        }

        // Collect Coins
        if (other.gameObject.tag == "grow")
        {
            other.gameObject.SetActive(false);
            // TODO: Add code to increase coins here
        }
    }
}
