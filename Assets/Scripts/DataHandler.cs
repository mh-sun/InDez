using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DataHandler : MonoBehaviour
{
    [SerializeField]
    ARSession aRSession;

    [SerializeField]
    ARPlaneManager aRPlaneManager;

    public GameObject furniture;
    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }
    
    public void ResetARSession()
    {
        for(int i = 0; i < SessionData.SpawnObject.Count; i++)
        {
            Debug.LogWarning(SessionData.SpawnObject.Count);
            Destroy(SessionData.SpawnObject[i]);
        }
        SessionData.SpawnObject = new List<GameObject>();
        SessionData.CurrentIndex = -1;

        aRSession.Reset();
    }

    public void ChangeARState()
    {
        aRPlaneManager.enabled = !aRPlaneManager.enabled;
    }
}
