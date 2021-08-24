using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Loadobjects
{
    Data userData;

    public Data loadData()
    {
        userData = new Data();
        string jsonData = ReadFromFile(SaveObjects.file);
        if(jsonData == null)
        {
            Debug.LogWarning("File not found");
            return null;
        }
        else
        {
            JsonUtility.FromJsonOverwrite(jsonData, userData);
            return userData;
        }
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
