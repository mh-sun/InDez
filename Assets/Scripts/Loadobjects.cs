using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Loadobjects
{
    Data userData;
    public void loadData()
    {
        userData = new Data();
        string jsonData = ReadFromFile(SaveObjects.file);
        JsonUtility.FromJsonOverwrite(jsonData, userData);
    }

    private string ReadFromFile(string file)
    {
        string path = GetFilePath(file);
        if (File.Exists(file))
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string jsonData = streamReader.ReadToEnd();
                return jsonData;
            }
        }
        return "File not found";
        
    }

    private string GetFilePath(string file)
    {
        return Application.persistentDataPath + "/" + file;
    }
}
