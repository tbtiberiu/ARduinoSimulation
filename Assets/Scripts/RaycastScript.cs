using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RaycastScript : MonoBehaviour
{
    public GameObject spawnedObject;
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                if (!IsPointerOverUIObject())
                {
                    spawnedObject.transform.position = hits[0].pose.position;
                }
            }
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData enentDataCurrentPosition = new PointerEventData(EventSystem.current);
        enentDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(enentDataCurrentPosition, results);
        return results.Count > 0;
    }
}
