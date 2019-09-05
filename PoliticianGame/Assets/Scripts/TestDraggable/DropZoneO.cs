using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DropZoneO : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private DeckManager deckManager;


    void Awake()
    {
        deckManager = GameObject.Find("GameManager").GetComponent<DeckManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entered: " + gameObject.name);
        if (eventData.pointerDrag == null)
            return;
        
        /*
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d != null)
        {
            d.m_PlaceholderParent = this.transform;
        }
        */
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit: " + gameObject.name);
        if (eventData.pointerDrag == null)
            return;
          
        /*
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d != null && d.m_PlaceholderParent == this.transform)
        {
            d.m_PlaceholderParent = d.m_ParentToReturn;
        }
        */
    }

    public void OnDrop(PointerEventData eventData)
    {
        /*
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d != null)
        {
            if (deckManager.SpendResource(eventData.pointerDrag.GetComponent<CardManager>().m_Card.cost))
                d.m_ParentToReturn = this.transform;
        }
        */
        Debug.Log("drasDropTO: " + gameObject.name);
    }

    void Update()
    {
        CheckForDropZones();
    }

    void CheckForDropZones()
    {
        RaycastHit[] hits;
        Ray ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, 100f, LayerMask.GetMask("DropZone"));
        if (hits.Length > 0)
        {
            Debug.Log(hits[0].transform.gameObject.name);

        }
    }
}
