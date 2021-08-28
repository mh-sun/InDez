using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    private int fileNotFoundOrEmpty = 111,UserFound = 222,UserNotFound = 333,UserPassMissmatched = 444;
    

    Users users;
    string file = "Profiles.pera";
    public InputField username;
    public InputField password;
    public Button login;
    public Button register;
    public Text text;
    public GameObject panel;

    string user, pass;
    public static bool isRegistering = false;

    public void exitApp()
    {
        Debug.LogWarning("Exit button Pressed");
        Application.Quit();
    }
    public void LogIn()
    {
        if(CheckUser() == UserFound)
        {
            SessionData.UserName = user;
            SceneManager.LoadScene("Choose");
        }
        else
        {
            text.text = "Invalid Credantials";
            panel.SetActive(true);
        }
    }
    public void Register()
    {
        isRegistering = true;
        int res = CheckUser();

        if (res == UserFound)
        {
            text.text = "User Already exits";
            panel.SetActive(true);
        }
        else if (res == UserPassMissmatched)
        {
            text.text = "User Already exits";
            panel.SetActive(true);
        }
        else
        {
            isRegistering = false;
            SessionData.UserName = user;
            SceneManager.LoadScene("Choose");
        }
        isRegistering = false;
    }

    public int CheckUser()
    {
        users = new Users();
        string jsonData = ReadFromFile(file);
        if (jsonData == null)
        {
            Debug.LogWarning("File not found");
            if (isRegistering)
            {
                SaveUserData(users);
            }
            return fileNotFoundOrEmpty;
        }
        else
        {
            JsonUtility.FromJsonOverwrite(jsonData, users);
        }

        for (int i = 0; i < users.name.Count; i++)
        {
            if (user == users.name[i])
            {
                if (pass == users.password[i])
                {
                    return UserFound;
                }
                else return UserPassMissmatched;
            }
            
        }
        if (isRegistering)
        {
            SaveUserData(users);
        }
            
        return UserNotFound;
    }

    private void SaveUserData(Users users)
    {
        users.name.Add(user);
        users.password.Add(pass);

        string jsonData = JsonUtility.ToJson(users);
        Debug.LogWarning(jsonData);
        WriteToFile(jsonData, file);
    }
    private void WriteToFile(string jsonData, string file)
    {
        string path = GetFilePath(file);
        Debug.Log(path);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(jsonData);
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

    private void Start()
    {
        InvokeRepeating("UpdateFractionTime", 0, .5f);
    }

    private void UpdateFractionTime()
    {

        user = username.text;
        pass = password.text;
        if (user == null || user == "" || pass == null || pass == "")
        {
            login.interactable = false;
            register.interactable = false;
        }
        else
        {
            login.interactable = true;
            register.interactable = true;
        }
    }

    public void next()
    {
        SessionData.UserName = user;
        SceneManager.LoadScene("Choose");
    }
}
