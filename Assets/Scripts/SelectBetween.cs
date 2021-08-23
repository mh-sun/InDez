using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SelectBetween : MonoBehaviour
{
    [SerializeField]
    private Camera ARCamera;

    [SerializeField]
    ARRaycastManager m_RaycastManager;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    public Vector2 TouchPosition { get; private set; }
    public float RotateValue { get; private set; }
    public float ScaleValue { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.sign != null)
        {
            if (InputManager.sign != "X")
            {
                return;
            }
        }
        else return;

        if (Input.touchCount > 0)
        {
            Debug.LogError("4444");
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;
            if (IsPointerOverUI(touch))
                return;
            if (touch.phase == TouchPhase.Began)
            {
                /*
                Debug.LogError("555");
                Ray ray = ARCamera.ScreenPointToRay(TouchPosition);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    Debug.LogError("666");
                    GameObject gameObject = hitObject.transform.GetComponent<GameObject>();
                    Debug.LogError(gameObject.name);
                    if (gameObject != null)
                    {
                        Debug.LogError("777");
                        for (int i=0; i < InputManager.spawnedObjects.Count; i++)
                        {
                            if(gameObject.name == InputManager.spawnedObjects[i].name)
                            {
                                Debug.LogError("888");
                                InputManager.spawnedObjects[i].transform.eulerAngles = new Vector3(0, RotateValue, 0);
                                InputManager.spawnedObjects[i].transform.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
                                break;
                            }
                        }
                        
                    }
                }
                if (m_RaycastManager.Raycast(touch.position, m_Hits, TrackableType.All))
                {
                    Debug.LogError("666");
                    Pose pose = m_Hits[0].tra;

                    Debug.LogError("777");
                    for (int i = 0; i < InputManager.spawnedObjects.Count; i++)
                    {
                        if (pose == InputManager.spawnedObjects[i].transform.position)
                        {
                            Debug.LogError("888");
                            InputManager.spawnedObjects[i].transform.eulerAngles = new Vector3(0, RotateValue, 0);
                            InputManager.spawnedObjects[i].transform.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
                            break;
                        }
                    }
                }
                else Debug.LogError("No hit found");*/
            }
        }
    }
    private bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults.Count > 0;
    }
    public void SetRotation(float rotateValue)
    {
        RotateValue = rotateValue;
    }

    public void SetScale(float scaleValue)
    {
        ScaleValue = scaleValue;
    }
}
