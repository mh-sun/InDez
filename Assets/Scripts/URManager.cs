using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class URManager : MonoBehaviour
{
    Stack<int> UndoIndices = new Stack<int>();
    [SerializeField]
    private Text TempText;

    private void Update()
    {
        TempText.text = SessionData.CurrentIndex.ToString();
    }

    public void UndoObject()
    {
        Debug.Log(DataHandler.Instance.furniture.name);
        if (SessionData.CurrentIndex < 0) 
            return;

        UndoIndices.Push(SessionData.CurrentIndex);

        SessionData.SpawnObject[SessionData.CurrentIndex].SetActive(false);

        for(int i= SessionData.CurrentIndex; i>=0;i--)
        {
            if (SessionData.SpawnObject[i].activeSelf)
            {
                SessionData.CurrentIndex = i;
                break;
            }
        }
        
    }
    public void RedoObject()
    {
        if (UndoIndices.Count <= 0) 
            return;

        int PopIndex = UndoIndices.Pop();
        SessionData.SpawnObject[PopIndex].SetActive(true);

        SessionData.CurrentIndex = PopIndex;
    }

}
