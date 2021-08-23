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
        foreach(GameObject gameObject in SessionData.SpawnObject)
        {
            objects.Add(gameObject.name);
        }
    }
}
