using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class BlockRaycast : MonoBehaviour {

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        // TODO: Investigate further - I don't know why only GUI elements return a count of greater than 1
        return results.Count > 1;
    }
}
