using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class URManager : MonoBehaviour
{
    Stack<int> UndoIndices = new Stack<int>();

    public Slider rotateSlider;
    public Slider scaleSlider;

    public void UndoObject()
    {
        
        if (SessionData.CurrentIndex < 0) 
            return;

        UndoIndices.Push(SessionData.CurrentIndex);

        SessionData.SpawnObject[SessionData.CurrentIndex].SetActive(false);

        for(int i= SessionData.CurrentIndex; i>=0;i--)
        {
            if (SessionData.SpawnObject[i].activeSelf)
            {
                SessionData.CurrentIndex = i;

                rotateSlider.value = SessionData.SpawnObjectRotaion[i];
                scaleSlider.value = SessionData.SpawnObjectScale[i];
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
        rotateSlider.value = SessionData.SpawnObjectRotaion[PopIndex];
        scaleSlider.value = SessionData.SpawnObjectScale[PopIndex];
    }

}
