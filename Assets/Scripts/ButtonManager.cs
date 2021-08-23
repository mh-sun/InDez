using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button button;
    public GameObject furniture;
    private int transpositonIndex = 3;
    private int tempPositionIndex = 2;
    private int normalIndex = 1;

    void Start()
    {
        button = GetComponent<Button>();
    }
    private void Update()
    {

        if (LoadManager.isActive)
        {
            if (SelectForLoad.Instance.OnEntered(gameObject))
            {
                transform.localScale = Vector3.one * tempPositionIndex;
                DataHandler.Instance.furniture = furniture;
            }

            else
                transform.localScale = Vector3.one * normalIndex;
        }
        else
        {
            if (Selector.Instance.OnEntered(gameObject))
            {
                transform.localScale = Vector3.one * transpositonIndex;
                DataHandler.Instance.furniture = furniture;
            }

            else
                transform.localScale = Vector3.one * normalIndex;
        }
        
    }


  
}
