﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacedObject : MonoBehaviour
{

    public ARRaycastManager raycast;
    public GameObject placementIndicator;

    // Start is called before the first frame update
    void Start()
    {
        raycast = FindObjectOfType<ARRaycastManager>();
        placementIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hitpoint = new List<ARRaycastHit>();

        raycast.Raycast(new Vector2(Screen.width/2, Screen.height/2), hitpoint, TrackableType.Planes);

        if(hitpoint.Count > 0)
        {
            placementIndicator.transform.position = hitpoint[0].pose.position;
            placementIndicator.transform.rotation = hitpoint[0].pose.rotation;

            if(!placementIndicator.activeInHierarchy)
            {
                placementIndicator.SetActive(true);
            }
        }

    }
}
