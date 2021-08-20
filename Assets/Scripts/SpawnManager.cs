using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectState);
    }

    private void SelectState()
    {
        if(button.GetComponentInChildren<Text>().text == "X")
        {
            button.GetComponentInChildren<Text>().text = "O";
            button.GetComponent<Image>().color = Color.green;
        }
        else{
            button.GetComponentInChildren<Text>().text = "X";
            button.GetComponent<Image>().color = Color.red;
        }
            

    }

    void Update()
    {
        
    }
}
