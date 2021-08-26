﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static string sign;
    [SerializeField]
    private Camera ARCamera;

    [SerializeField]
    private ARRaycastManager raycastManager;

    [SerializeField]
    private Text text;

    [SerializeField]
    private GameObject SRPanel;


    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Touch touch;

    private void Update()
    {
        sign = text.text;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Began)
            {
                return;
            }
            if (IsPointerOverUI(touch))
                return;

            if (text != null)
            {
                if (text.text == "X")
                {
                    return;
                }
            }
            else return;

            Ray ray = ARCamera.ScreenPointToRay(touch.position);
            if (raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                GameObject spawnedObject = Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);

                SessionData.CurrentIndex = SessionData.SpawnObject.Count;

                SessionData.SpawnObject.Add(spawnedObject);
            }
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

    public void Back()
    {
        Debug.LogWarning("Back button Pressed");
        SceneManager.LoadScene("Choose");
    }
    public void Exit()
    {
        Debug.LogWarning("Quit button Pressed");
        Application.Quit();
    }
}
