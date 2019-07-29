using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<GameObject> m_Cards;

    public Transform m_Hand;


    public void NewRandomDeck()
    {

    }

    public void DrawCard()
    {
        if (GetCardsCount() == 0)
            return;

        GameObject cardToDraw = m_Cards[0];
        m_Cards.RemoveAt(0);

        GameObject card = Instantiate(cardToDraw);
        card.transform.SetParent(m_Hand);
    }

    public int GetCardsCount()
    {
        return m_Cards.Count;
    }

    public void ShuffleDeck()
    {
        List<GameObject> newDeck = new List<GameObject>();
        int totalCards = GetCardsCount();
        for (int i = 0; i < totalCards; i++)
        {
            int rng = Random.Range(0, m_Cards.Count);
            newDeck.Add(m_Cards[rng]);
        }
        m_Cards = newDeck;
    }

    public GameObject GetRandomCard()
    {
        if (GetCardsCount() == 0)
            return null;
        int rng = Random.Range(0, GetCardsCount());
        return m_Cards[rng];
    }



}
