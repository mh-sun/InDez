using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRManager : MonoBehaviour
{
    private GameObject obj;
    private float RotateValue = 180, ScaleValue = 1;

    [SerializeField]
    private GameObject SRPanel;

    [SerializeField]
    private GameObject SRPopUp;

    private void Start()
    {
        SRPopUp.SetActive(!SRPanel.activeSelf);
    }

    private void Update()
    {
        if (SessionData.CurrentIndex == -1)
            return;
        if(SessionData.SpawnObject.Count > 0)
        {
            SessionData.SpawnObject[SessionData.CurrentIndex].transform.eulerAngles = new Vector3(0, RotateValue, 0);
            SessionData.SpawnObject[SessionData.CurrentIndex].transform.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
        }
        
    }

    public void SetRotation(float rotateValue)
    {
        RotateValue = rotateValue;
    }

    public void SetScale(float scaleValue)
    {
        ScaleValue = scaleValue;
    }

    public void Dismiss()
    {
        SRPanel.SetActive(false);
        SRPopUp.SetActive(true);
    }
    public void PopUpSR()
    {
        SRPanel.SetActive(true);
        SRPopUp.SetActive(false);
    }

}
