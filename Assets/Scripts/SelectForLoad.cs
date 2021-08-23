using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectForLoad : MonoBehaviour
{
    private GraphicRaycaster graphicRaycaster;
    private PointerEventData eventData;
    private EventSystem eventSystem;

    public Transform selectionPoint;

    private static SelectForLoad instance;
    public static SelectForLoad Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SelectForLoad>();
            }
            return instance;
        }
    }

    private void Start()
    {
        graphicRaycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        eventData = new PointerEventData(eventSystem);
        eventData.position = selectionPoint.position;
    }
    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> hits = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, hits);

        foreach (RaycastResult hit in hits)
        {
            if (hit.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }
}
