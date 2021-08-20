using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Stack<int> UndoIndices;

    private void Update()
    {
        
    }

    public void UndoObject()
    {

        

        for (int i = 0; i < 5; i++)
        {
            testScript.spawnedObjects[0].SetActive(false);
        }


        

    }
    public void RedoObject()
    {
        if (UndoIndices.Count <= 0)
            return;

        int PopIndex = UndoIndices.Pop();
        testScript.spawnedObjects[PopIndex].SetActive(true);

        testScript.CurrentIndex = PopIndex;
    }
}
