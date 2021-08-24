using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public GameObject LoadPanel;

    public GameObject LoadButton;

    public GameObject MainPanel;

    public List<GameObject> AllObjects;

    public static bool isActive;

    Loadobjects loadobjects = new Loadobjects();
    List<string> objects;

    private void Start()
    {
        LoadPanel.SetActive(false);
    }

    public void ChangeState()
    {
        if (LoadPanel.activeSelf)
        {
            LoadPanel.SetActive(false);
            isActive = false;
            MainPanel.SetActive(true);
        }
        else
        {
            IntantiateObjects();
            LoadPanel.SetActive(true);
            isActive = true;
            MainPanel.SetActive(false);
        }
    }

    private void IntantiateObjects()
    {
        if (loadobjects.loadData() == null)
        {
            return;
        }
        else
        {
            objects = loadobjects.loadData().objects;
        }
        

        foreach(GameObject gameObject in AllObjects)
        {
            gameObject.SetActive(false);

            foreach (string name in objects)
            {
                if(gameObject.name == name)
                {
                    gameObject.SetActive(true);
                }
            }
        }
        
    }
}
