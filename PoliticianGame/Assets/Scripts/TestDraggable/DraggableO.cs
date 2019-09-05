using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DraggableO : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Transform m_ParentToReturn;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Dragging");
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Debug.Log("Dragging");
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                          Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                          -0.5f);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CheckForDropZones();
        this.transform.SetParent(m_ParentToReturn);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    void CheckForDropZones()
    {
        RaycastHit[] hits;
        Ray ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, 100f, LayerMask.GetMask("DropZone"));
        if (hits.Length > 0)
        {
            Debug.Log(hits[0].transform.gameObject.name);
            m_ParentToReturn = hits[0].transform;
        }
    }

}
