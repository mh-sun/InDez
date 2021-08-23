using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveObjects : MonoBehaviour
{
    Data userdata;
    public static string file = "userData.txt";
    public void saveObject()
    {
        InstantiateData();
        string jsonData = JsonUtility.ToJson(userdata);
        WriteToFile(jsonData, file);
    }

    private void InstantiateData()
    {
        if (SessionData.UserName == null)
            userdata = new Data();
        else userdata = new Data(SessionData.UserName);

    }

    private void WriteToFile(string jsonData, string file)
    {
        string path = GetFilePath(file);
        Debug.Log(path);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        
        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(jsonData);
        }
    }

    private string GetFilePath(string file)
    {
        return Application.persistentDataPath + "/" + file;
    }
}
