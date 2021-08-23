using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Loadobjects : MonoBehaviour
{
    Data userData;

    public void loadData()
    {
        userData = new Data();
        string jsonData = ReadFromFile(SaveObjects.file);
        if(jsonData == null)
        {
            Debug.LogWarning("File not found");
            return;
        }
        else JsonUtility.FromJsonOverwrite(jsonData, userData);
    }

    private string ReadFromFile(string file)
    {
        string path = GetFilePath(file);
        Debug.Log(path);
        if (File.Exists(path))
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string jsonData = streamReader.ReadToEnd();
                Debug.Log(jsonData);
                return jsonData;
            }
        }
        return null;
        
    }

    private string GetFilePath(string file)
    {
        return Application.persistentDataPath + "/" + file;
    }
}
