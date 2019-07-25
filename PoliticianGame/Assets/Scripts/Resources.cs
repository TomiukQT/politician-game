using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    #region PEOPLE

    public int m_Residents = 10000000; //10M

    public int m_ResientsInc = 150;
    public int m_ResidentsDec = 150;

    [Space]
    //AGE
    public int m_Youngs;
    public int m_Adults;
    public int m_Pensioners;

    public int m_YoungsReputation;
    public int m_AdultsReputation;
    public int m_PensionersReputation;


    [Space]
    //EDUCATION
    public int m_Elementary;
    public int m_HighSchool;
    public int m_University;

    public int m_ElementaryReputation;
    public int m_HighSchoolReputation;
    public int m_UniversityReputation;

    [Space]
    //RELIGION
    public int m_Atheists;
    public int m_Christians;
    public int m_Jews;
    public int m_Muslims;
    public int m_OtherReligion;

    public int m_AtheistsReputation;
    public int m_ChristiansReputation;
    public int m_JewsReputation;
    public int m_MuslimsReputation;
    public int m_OtherReligionReputation;

    [Space]
    //LIVING PLACE
    public int m_City;
    public int m_Village;

    public int m_CityReputation;
    public int m_VillageReputation;

    [Space]
    //LOCAL/FOREIGNER
    public int m_Locals;
    public int m_Foreigners;

    public int m_LocalsReputation;
    public int m_ForeignersReputation;


    #endregion

    public GameObject[] m_Graphs;
    void Start()
    {
        DivideResources();
        MakeGraphs();
    }




    //TODO : Scenarios
    void DivideResources()
    {
        DivideAge();
        DivideEducation();
        DivideReligion();
        DividePlace();
        DivideOrigin();

    }


    void DivideAge()
    {
        m_Adults = GetRandomAmount(35, 45);
        m_Pensioners = GetRandomAmount(20, 25);
        m_Youngs = m_Residents - (m_Adults + m_Pensioners);
    }

    void DivideEducation()
    {
        m_Elementary = GetRandomAmount(35, 45);
        m_HighSchool = GetRandomAmount(35, 45);
        m_University = m_Residents - (m_Elementary + m_HighSchool);
    }

    void DivideReligion()
    {
        
        m_Christians = GetRandomAmount(10, 30);
        m_Jews = GetRandomAmount(2, 5);
        m_Muslims = GetRandomAmount(2, 3);
        m_OtherReligion = GetRandomAmount(2,6);
        m_Atheists = m_Residents - (m_Christians + m_Jews + m_Muslims + m_OtherReligion);
    }

    void DividePlace()
    {
        m_City = GetRandomAmount(45, 75);
        m_Village = m_Residents - m_City;
    }

    void DivideOrigin()
    {
        m_Locals = GetRandomAmount(85, 95);
        m_Foreigners = m_Residents - m_Locals;
    }

    private int GetRandomAmount(float percentageLow, float percentageHigh)
    {
        float percentage = Random.Range(percentageLow, percentageHigh);
        percentage /= 100;
        return (int)(m_Residents * percentage);
    }

    void MakeGraphs()
    {
        m_Graphs[0].GetComponent<PieGraph>().GetData(new int[] { m_Adults,m_Pensioners,m_Youngs },m_Residents, new string[] {"Adults","Pensioners", "Youngs" });
        m_Graphs[1].GetComponent<PieGraph>().GetData(new int[] {m_Elementary,m_HighSchool,m_University },m_Residents, new string[] {"Elementary","High School","University" });
        m_Graphs[2].GetComponent<PieGraph>().GetData(new int[] { m_Atheists,m_Christians,m_Jews,m_Muslims,m_OtherReligion },m_Residents, new string[] {"Atheists","Christians","Jews","Muslims","Other Religion" });
        m_Graphs[3].GetComponent<PieGraph>().GetData(new int[] { m_City,m_Village },m_Residents, new string[] {"City","Village" });
        m_Graphs[4].GetComponent<PieGraph>().GetData(new int[] { m_Locals,m_Foreigners},m_Residents, new string[] {"Locals","Foreigners" });
    }
   
    void Update()
    {
        
    }

    void Increment()
    {
        m_Residents += m_ResientsInc;
        m_Residents -= m_ResidentsDec;

        IncrementAge();
        IncrementEducation();
        IncrementReligion();
    }

    void IncrementAge()
    {
        for (int i = 0; i < m_ResientsInc; i++)
        {
            int totalRep = m_YoungsReputation + m_AdultsReputation + m_PensionersReputation;
            int rng = Random.Range(0, totalRep);
            if (rng < m_YoungsReputation)
                m_Youngs++;
            else if (rng < (m_YoungsReputation + m_AdultsReputation))
                m_Adults++;
            else
                m_Pensioners++;
        }
        for (int i = 0; i < m_ResidentsDec; i++)
        {
            float youngs = (1 / m_YoungsReputation) * 100;
            float adults = (1 / m_AdultsReputation) * 100;
            float pensioners = (1 / m_PensionersReputation) * 100;
            float total = youngs + adults + pensioners;

            float rng = Random.Range(0, total);
            if (rng < youngs)
                m_Youngs--;
            else if (rng < (youngs + adults))
                m_Adults--;
            else
                m_Pensioners--;

        }
    }
    void IncrementEducation()
    {
        
    }

    void IncrementReligion()
    {
       
    }
}
