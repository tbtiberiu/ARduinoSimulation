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

    private bool isPinching = false;
    private Vector2 initialTouch0Position;
    private Vector2 initialTouch1Position;
    private float initialRotationY;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                initialTouch0Position = touch0.position;
                initialTouch1Position = touch1.position;

                initialRotationY = spawnedObject.transform.eulerAngles.y;
                isPinching = true;
            }
            else if (touch0.phase == TouchPhase.Ended || touch1.phase == TouchPhase.Ended)
            {
                isPinching = false;
            }

            if (isPinching && raycastManager.Raycast(touch0.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Vector2 currentTouch0Position = touch0.position;
                Vector2 currentTouch1Position = touch1.position;

                float initialAngle = Mathf.Atan2(initialTouch1Position.y - initialTouch0Position.y, initialTouch1Position.x - initialTouch0Position.x) * Mathf.Rad2Deg;
                float currentAngle = Mathf.Atan2(currentTouch1Position.y - currentTouch0Position.y, currentTouch1Position.x - currentTouch0Position.x) * Mathf.Rad2Deg;

                float rotationAngle = currentAngle - initialAngle;

                float newRotationY = initialRotationY - rotationAngle;
                spawnedObject.transform.rotation = Quaternion.Euler(0f, newRotationY, 0f);
            }
        }
        else if (Input.touchCount > 0)
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
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
