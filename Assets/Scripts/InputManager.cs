using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    /*public GameObject objectToPlace;
    public GameObject placementIndicator;

    private ARRaycastManager raycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    */

    //[SerializeField] private GameObject ObjectToPlace;
    [SerializeField]
    private Camera ARCamera;

    [SerializeField]
    private ARRaycastManager raycastManager;

    [SerializeField]
    private Text text;

    [SerializeField]
    private GameObject SRPanel;


    public static int CurrentIndex=-1;
    public static List<GameObject> spawnedObjects = new List<GameObject>();

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Touch touch;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        touch = Input.GetTouch(0);

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
        {
            return;
        }
        if (IsPointerOverUI(touch))
            return;

        if (text.text == "X")
        {
            return;
        }    

        Ray ray = ARCamera.ScreenPointToRay(touch.position);
        if (raycastManager.Raycast(ray, hits))
        {
            Pose pose = hits[0].pose;
            GameObject spawnedObject = Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);
            
            CurrentIndex = spawnedObjects.Count;

            spawnedObjects.Add(spawnedObject);
        }

        
    }

    private bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults.Count > 0;
    }

}
