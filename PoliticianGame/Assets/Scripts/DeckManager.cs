using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DeckManager : MonoBehaviour
{
    public GameObject m_CardPrefab;
    public List<Card> m_Cards;

    public Card[] m_AllCards;

    public Transform m_Hand;
    private int m_MaxHandSize = 6;
    public int m_CurrHandSize;


    public float m_MaxResource = 10f;
    private float m_CurrResource;
    public TextMeshProUGUI m_ResourceText;
  


    private void Start()
    {
        NewRandomDeck();
        m_CurrHandSize = m_Hand.childCount;
        m_CurrResource = m_MaxResource;

    }

    void Update()
    {
        UpdateUI();
    }
        
    void UpdateUI()
    {
        m_ResourceText.text = m_CurrResource.ToString("0") + "/" + m_MaxResource.ToString("0");
    }


    public void NewRandomDeck()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < m_AllCards.Length; j++)
            {
                m_Cards.Add(m_AllCards[j]);
            }
        }

        ShuffleDeck();
    }

    public void DrawCard()
    {
        if (GetCardsCount() == 0)
            return;
        else if (m_CurrHandSize >= m_MaxHandSize)
            return;

        Card cardToDraw = m_Cards[0];
        m_Cards.RemoveAt(0);
        m_CurrHandSize++;
        GameObject card = Instantiate(m_CardPrefab);
        card.GetComponent<CardManager>().m_Card = cardToDraw;
        card.GetComponent<CardManager>().UpdateCard();
        card.transform.SetParent(m_Hand);
    }

    public int GetCardsCount()
    {
        return m_Cards.Count;
    }

    public void ShuffleDeck()
    {
        List<Card> newDeck = new List<Card>();
        int totalCards = GetCardsCount();
        for (int i = 0; i < totalCards; i++)
        {
            int rng = Random.Range(0, m_Cards.Count);
            newDeck.Add(m_Cards[rng]);
        }
        m_Cards = newDeck;
    }

    public Card GetRandomCard()
    {
        if (GetCardsCount() == 0)
            return null;
        int rng = Random.Range(0, GetCardsCount());
        return m_Cards[rng];
    }

    public bool SpendResource(float amount)
    {
        if (amount >= m_CurrResource)
        {
            m_CurrResource -= amount;
            return true;
        }


        return false;
    }

    public void RestoreResource(float amount)
    {
        m_CurrResource += amount;
        if (m_CurrResource > m_MaxResource)
            RestoreResource();
    }

    public void RestoreResource()
    {
        m_CurrResource = m_MaxResource;
    }
    


}
