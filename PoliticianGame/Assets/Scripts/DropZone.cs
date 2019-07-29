using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems; 
using UnityEngine;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{   

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d != null)
        {
            d.m_PlaceholderParent = this.transform;
        }
        //  Debug.Log("Entered: " + gameObject.name);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        //  Debug.Log("Exit: " + gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d != null && d.m_PlaceholderParent == this.transform)
        {
            d.m_PlaceholderParent = d.m_ParentToReturn;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d != null)
        {
            d.m_ParentToReturn = this.transform;
        }
        //Debug.Log("drasDropTO: " + gameObject.name)
    }
}
