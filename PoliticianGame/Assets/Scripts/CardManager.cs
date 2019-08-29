using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{

    private Resources r;

    public Card m_Card;

    public Image m_CardImage;
    public TextMeshProUGUI m_CardName;
    public TextMeshProUGUI m_CardDesc;

    private DeckManager m_DeckManager;
    private Database m_Database;

    private void Awake()
    {
        r = GameObject.Find("ResourceManager").GetComponent<Resources>();
        m_DeckManager = GameObject.Find("GameManager").GetComponent<DeckManager>();
        m_Database = GameObject.Find("DatabaseManager").GetComponent<Database>();

        if (m_Card.cardEffect == Card.Effect.DrawCard)
            this.gameObject.AddComponent<DrawCardEffect>();
    }

    private void Start()
    {
        UpdateCard();
    }


    public void UpdateCard()
    {
        m_CardImage.sprite = m_Card.image;
        m_CardName.text = m_Card.cardName;
        m_CardDesc.text = m_Card.description + "\n Cost: " + m_Card.cost + "\n" + GetComponent<BaseEffect>().GetEffectName();
    }

    private void SendCard()
    {
        m_Database.InsertCard(m_Card.cardName, (int)m_Card.cost, "TEMPDEV", "DEBUG");
    }

    public void PlayCard()
    {
        SendCard();
        gameObject.GetComponent<DrawCardEffect>().Apply();
        m_DeckManager.m_CurrHandSize--;
        StartCoroutine(WaitToPlay());
    }

    IEnumerator WaitToPlay(float playTime = 1f)
    {
        yield return new WaitForSeconds(playTime);
        GainBonuses();
        Destroy(gameObject);
    }

    public void GainBonuses()
    {
        foreach (var item in m_Card.GetBonuses())
        {
            GainBonus(item.Key, item.Value);
        }
    }

    private void GainBonus(string key, int value)
    {
        switch(key)
        {
            case "Youngs":
                r.m_YoungsReputation += value;
                break;
            case "Adults":
                r.m_AdultsReputation += value;
                break;
            case "Pensioners":
                r.m_PensionersReputation += value;
                break;
            case "Elementary":
                r.m_ElementaryReputation += value;
                break;
            case "HighSchool":
                r.m_HighSchoolReputation += value;
                break;
            case "University":
                r.m_UniversityReputation += value;
                break;
            case "Christians":
                r.m_ChristiansReputation += value;
                break;
            case "Jews":
                r.m_JewsReputation += value;
                break;
            case "Muslims":
                r.m_MuslimsReputation += value;
                break;
            case "Other":
                r.m_OtherReligionReputation += value;
                break;
            case "Atheists":
                r.m_AtheistsReputation += value;
                break;
            case "City":
                r.m_CityReputation += value;
                break;
            case "Village":
                r.m_VillageReputation += value;
                break;
            case "Locals":
                r.m_LocalsReputation += value;
                break;
            case "Foreigners":
                r.m_ForeignersReputation += value;
                break;
            default:
                Debug.LogError("Unknown bonus.");
                break;


        }
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
    