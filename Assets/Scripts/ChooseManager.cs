using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseManager : MonoBehaviour
{
    public void Back()
    {
        Debug.LogWarning("Back button Pressed");
        SessionData.UserName = null;
        SceneManager.LoadScene("Login");

    }
    public void quit()
    {
        Debug.LogWarning("Exit button Pressed");
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene("ApplicationScene");
    }
    public void Office()
    {
        SceneManager.LoadScene("Office");
    }

}
