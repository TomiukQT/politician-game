using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public GameObject m_CardPrefab;
    public List<Card> m_Cards;

    public Card[] m_AllCards;

    public Transform m_Hand;

    private void Start()
    {
        NewRandomDeck();
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

        Card cardToDraw = m_Cards[0];
        m_Cards.RemoveAt(0);

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



}
