using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionData : MonoBehaviour
{
    public static int CurrentIndex = -1;
    public static string UserName ;
    public static List<GameObject> SpawnObject = new List<GameObject>();
    public static List<float> SpawnObjectRotaion = new List<float>();
    public static List<float> SpawnObjectScale = new List<float>();
    public static List<string> AllObjectName;

}
