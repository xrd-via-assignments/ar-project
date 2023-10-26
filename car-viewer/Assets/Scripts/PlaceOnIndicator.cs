using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnIndicator : MonoBehaviour
{
    [SerializeField]
    GameObject placementIndicator;
    [SerializeField]
    GameObject placedPrefab;

    GameObject spawnedObject;

    [SerializeField]
    Button placeButton;



    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();



    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();

        placementIndicator.SetActive(false);

        // Enable the button at the start
        placeButton.interactable = true;
    }

    private void Update()
    {
        // If the object has been placed, do nothing with the placementIndicator
        if (spawnedObject != null)
        {
            return;
        }

        if (aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            placementIndicator.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);

            if (!placementIndicator.activeInHierarchy)
                placementIndicator.SetActive(true);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    public void PlaceObject()
    {
        if (!placementIndicator.activeInHierarchy)
            return;

        if (spawnedObject == null)
        {
            // Instantiate the object
            spawnedObject = Instantiate(placedPrefab, placementIndicator.transform.position, placementIndicator.transform.rotation);
            // Hide or deactivate the placementIndicator
            placementIndicator.SetActive(false);
            // Disable the Button GameObject
            placeButton.gameObject.SetActive(false);
        }

        // else
        // {
        //     // Update the position and rotation of the spawned object
        //     spawnedObject.transform.SetPositionAndRotation(placementIndicator.transform.position, placementIndicator.transform.rotation);
        // }
    }
}
