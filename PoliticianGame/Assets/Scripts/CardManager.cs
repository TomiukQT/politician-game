﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{

    public Card m_Card;

    public Image m_CardImage;
    public TextMeshProUGUI m_CardName;
    public TextMeshProUGUI m_CardDesc;

    private void Awake()
    {
        
    }

    private void Start()
    {
        m_CardImage.sprite = m_Card.image;
        m_CardName.text = m_Card.cardName;
        m_CardDesc.text = m_Card.description + "\n Cost: " + m_Card.cost; 
    }

    public void UpdateCard()
    {
        m_CardImage.sprite = m_Card.image;
        m_CardName.text = m_Card.cardName;
        m_CardDesc.text = m_Card.description + "\n Cost: " + m_Card.cost;
    }

    public void PlayCard()
    {
        PrintCard();

        Destroy(gameObject,1f);
    }

    private void PrintCard()
    {
        string s = "CARD BONUSES: \n";

        foreach ( var item in m_Card.GetBonuses())
        {
            s += item.Key+ ": " + item.Value + " -- ";

        }
        Debug.Log(s);

    }

   
}
