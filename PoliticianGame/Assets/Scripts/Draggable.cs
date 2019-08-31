using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform m_ParentToReturn = null;
    public Transform m_PlaceholderParent = null;
    public GameObject m_Placeholder;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start");

        m_Placeholder = new GameObject();
        m_Placeholder.transform.SetParent(this.transform.parent);
        LayoutElement layoutElement = m_Placeholder.AddComponent<LayoutElement>();
        layoutElement.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        layoutElement.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        layoutElement.flexibleHeight = 0;
        layoutElement.flexibleWidth = 0;

        m_Placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        m_ParentToReturn = this.transform.parent;
        m_PlaceholderParent = m_ParentToReturn;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("Dragging");
        transform.position = eventData.position;

        if (m_Placeholder.transform.parent != m_PlaceholderParent)
            m_Placeholder.transform.SetParent(m_PlaceholderParent);

        int newSiblingIndex = m_PlaceholderParent.childCount;

        for (int i = 0; i < m_PlaceholderParent.childCount; i++)
        {
            if (this.transform.position.x < m_PlaceholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if(m_Placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }

                
                break;
            }
        }

        m_Placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("End");
        Destroy(m_Placeholder); 
        
        this.transform.SetParent(m_ParentToReturn);
        this.transform.SetSiblingIndex(m_Placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(m_ParentToReturn.gameObject.name == "CardDrop" && this.tag == "Card")
        {
            transform.GetComponent<CardManager>().PlayCard();
            Destroy(GetComponent<Draggable>());
        }
    }


}
