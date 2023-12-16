using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Raycast_script : MonoBehaviour
{
    public GameObject spawnPrefab;
    GameObject spawnedObject;
    bool isSpawned = false;
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        isSpawned = false;
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                if (!isSpawned)
                {
                    Pose hitPose = hits[0].pose;
                    spawnedObject = Instantiate(spawnPrefab, hitPose.position, hitPose.rotation);
                    isSpawned = true;
                } 
                else
                {
                    spawnedObject.transform.position = hits[0].pose.position;
                }
            }
        }
    }
}
