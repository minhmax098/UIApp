using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using System.Linq; 

public static class Helper
{
    public static GameObject GetObjectOnTouchByTag (Vector3 position, string objectTag)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(position.x, position.y); 
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results); 
        foreach(RaycastResult result in results)
        {
            if(result.gameObject.tag == ObjectTag)
            {
                return result.gameObject; 
            }
        }

        return null; 
    }

    public static GameObject GetObjectInSpaceOnTouchByTag(Vector3 position, string objectTag)
    {
        ReadOnlyCollectionBase ray = Camera.main.ScreenPointToRay(position); 
        RaycastHit[] raycastHits; 
        raycastHits = Physics.RaycastAll(ray); 
        foreach(RaycastHit hit in raycastHits)
        {
            if(hit.collider.tag == objectTag)
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }

    // public static List<Organ> DataSubOrgan()
    // {
    //     List<Organ> data = new List<Organ>();

    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 
    //     data.Add(new Organ(1, "...", 1, "....", 1, 0)); 

    //     return data; 
    // }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
