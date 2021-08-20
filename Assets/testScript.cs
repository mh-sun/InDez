using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public GameObject test;
    public static int CurrentIndex = -1;
    public static List<GameObject> spawnedObjects = new List<GameObject>();
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
        
        for(int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(test, test.transform, false);
            obj.transform.parent = parent.transform;
            Debug.Log(obj);
            spawnedObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
