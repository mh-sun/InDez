using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public string UserName;
    public bool isGuest;
    public List<string> objects;

    public Data()
    {
        isGuest = true;
        Loadobjects();
    }

    public Data(string UserName)
    {
        isGuest = false;
        this.UserName = UserName;
        Loadobjects();
    }
    private void Loadobjects()
    {
        objects = new List<string>();
        for(int i = 0; i < SessionData.SpawnObject.Count; i++)
        {
            if (SessionData.SpawnObject[i].activeSelf)
            {
                objects.Add(SessionData.SpawnObject[i].name);
            }
        }
    }
}
