using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class URManager : MonoBehaviour
{
    Stack<int> UndoIndices;
    [SerializeField]
    private Text TempText;

    private void Update()
    {
        TempText.text = InputManager.CurrentIndex.ToString();
    }

    public void UndoObject()
    {
        if (InputManager.CurrentIndex < 0) 
            return;

        UndoIndices.Push(InputManager.CurrentIndex);

        InputManager.spawnedObjects[InputManager.CurrentIndex].SetActive(false);

        for(int i= InputManager.CurrentIndex; i>=0;i--)
        {
            if (InputManager.spawnedObjects[i].activeSelf)
            {
                InputManager.CurrentIndex = i;
                break;
            }
        }
        
    }
    public void RedoObject()
    {
        if (UndoIndices.Count <= 0) 
            return;

        int PopIndex = UndoIndices.Pop();
        InputManager.spawnedObjects[PopIndex].SetActive(true);

        InputManager.CurrentIndex = PopIndex;
    }

}
