using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    private bool isOpen = false;

    public GameObject panel;
    public void ChangeState()
    {
        if (isOpen)
        {
            panel.SetActive(false);
            isOpen = false;
        }
        else
        {
            panel.SetActive(true);
            isOpen = true;
        }
    }
}
