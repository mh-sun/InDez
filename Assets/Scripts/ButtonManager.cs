using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button button;
    public GameObject furniture;
    private int transpositonIndex = 2;
    private int normalIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
/*        button.onClick.AddListener(SelectObject);*/
    }
    private void Update()
    {
        if (Selector.Instance.OnEntered(gameObject))
        {
            transform.localScale = Vector3.one * transpositonIndex;
            DataHandler.Instance.furniture = furniture;
        }
            
        else
            transform.localScale = Vector3.one * normalIndex;

    }

    /*private void SelectObject()
    {
        DataHandler.Instance.furniture = furniture;
    }*/

  
}
