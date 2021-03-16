using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public GameObject objectSpawn;
    public ARPlacedObject aRPlacedObject;
    public GameObject placementQuad;

    public bool SpawnOnce;
    private bool alloowMultipleSpawn = true;

    void Start()
    {
        // objectSpawn.transform.localRotation = Quaternion.Euler(-90, 0, 0);
    }


    void Update() 
    {
        if(alloowMultipleSpawn)
        {
            if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)    
            {
                GameObject arObj = Instantiate(objectSpawn, placementQuad.transform.position, placementQuad.transform.rotation);
                if(SpawnOnce == true)
                {
                    alloowMultipleSpawn = false;
                    placementQuad.transform.GetChild(0).transform.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }
}
