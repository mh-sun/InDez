using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class About : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    [SerializeField]
    Text text;

    private void Start()
    {
        if(SessionData.UserName == null || SessionData.UserName == "")
        {
            text.text = "Hello Guest";
        }
        else
            text.text = "Hello "+SessionData.UserName;
    }

    public void ChangeState()
    {
        if (canvas.activeSelf)
        {
            canvas.SetActive(false);
        }
        else canvas.SetActive(true);
    }
}
