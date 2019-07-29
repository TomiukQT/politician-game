using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            transform.GetComponent<DeckManager>().DrawCard();
        else if (Input.GetKeyDown(KeyCode.R))
            transform.GetComponent<DeckManager>().ShuffleDeck();
    }
}
