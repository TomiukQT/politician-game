using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DraggableO : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
 

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Dragging");
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Debug.Log("Dragging");
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                          Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                          0.0f);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }


}
