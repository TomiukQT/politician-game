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

    private void Awake()
    {
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        //Debug.Log("TICK: " + e.ticks);
        Increment();
    }

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
        m_OtherReligion = GetRandomAmount(2, 6);
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
        m_Graphs[0].GetComponent<PieGraph>().GetData(new int[] { m_Adults, m_Pensioners, m_Youngs }, m_Residents, new string[] { "Adults", "Pensioners", "Youngs" });
        m_Graphs[1].GetComponent<PieGraph>().GetData(new int[] { m_Elementary, m_HighSchool, m_University }, m_Residents, new string[] { "Elementary", "High School", "University" });
        m_Graphs[2].GetComponent<PieGraph>().GetData(new int[] { m_Atheists, m_Christians, m_Jews, m_Muslims, m_OtherReligion }, m_Residents, new string[] { "Atheists", "Christians", "Jews", "Muslims", "Other Religion" });
        m_Graphs[3].GetComponent<PieGraph>().GetData(new int[] { m_City, m_Village }, m_Residents, new string[] { "City", "Village" });
        m_Graphs[4].GetComponent<PieGraph>().GetData(new int[] { m_Locals, m_Foreigners }, m_Residents, new string[] { "Locals", "Foreigners" });
    }

    void Update()
    {

    }

    //
    //privat void TimeTickSystem_onTick(object sender, TimeTickSystem.OnTickEventargs e )

    void Increment()
    {
        m_Residents += m_ResientsInc;
        m_Residents -= m_ResidentsDec;

        IncrementAge();
        IncrementEducation();
        IncrementReligion();
        IncrementPlace();
        IncrementOrigin();

        UpdateGraphs();
    }

    void UpdateGraphs()
    {
        m_Graphs[0].GetComponent<PieGraph>().UpdateData(new int[] { m_Adults, m_Pensioners, m_Youngs }, m_Residents);
        m_Graphs[1].GetComponent<PieGraph>().UpdateData(new int[] { m_Elementary, m_HighSchool, m_University }, m_Residents);
        m_Graphs[2].GetComponent<PieGraph>().UpdateData(new int[] { m_Atheists, m_Christians, m_Jews, m_Muslims, m_OtherReligion }, m_Residents);
        m_Graphs[3].GetComponent<PieGraph>().UpdateData(new int[] { m_City, m_Village }, m_Residents);
        m_Graphs[4].GetComponent<PieGraph>().UpdateData(new int[] { m_Locals, m_Foreigners }, m_Residents);
    }

    void IncrementAge()
    {
        int totalRep = m_YoungsReputation + m_AdultsReputation + m_PensionersReputation;
        for (int i = 0; i < m_ResientsInc; i++)
        {
            int rng = Random.Range(0, totalRep);
            if (rng < m_YoungsReputation)
                m_Youngs++;
            else if (rng < (m_YoungsReputation + m_AdultsReputation))
                m_Adults++;
            else
                m_Pensioners++;
        }


        float youngs = (100 / m_YoungsReputation);
        float adults = (100 / m_AdultsReputation);
        float pensioners = (100 / m_PensionersReputation);
        float total = youngs + adults + pensioners;

        for (int i = 0; i < m_ResidentsDec; i++)
        {
            

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
        int totalRep = m_ElementaryReputation + m_HighSchoolReputation + m_UniversityReputation;
        for (int i = 0; i < m_ResientsInc; i++)
        {
            int rng = Random.Range(0, totalRep);

            if (rng < m_ElementaryReputation)
                m_Elementary++;
            else if (rng < (m_ElementaryReputation + m_HighSchoolReputation))
                m_HighSchool++;
            else
                m_University++;

        }

        float elem = (100 / m_ElementaryReputation);
        float high = (100 / m_HighSchoolReputation);
        float univ = (100 / m_UniversityReputation);
        float total = elem + high + univ;

        for (int i = 0; i < m_ResidentsDec; i++)
        {
            

            float rng = Random.Range(0, total);
            if (rng < elem)
                m_Elementary--;
            else if (rng < (elem + high))
                m_HighSchool--;
            else
                m_University--;
        }
    }

    void IncrementReligion()
    {
            int totalRep = m_ChristiansReputation + m_MuslimsReputation
                + m_JewsReputation + m_AtheistsReputation + m_OtherReligionReputation;
        for (int i = 0; i < m_ResientsInc; i++)
        {
            int rng = Random.Range(0, totalRep);
            if (rng < m_ChristiansReputation)
                m_Christians++;
            else if (rng < (m_ChristiansReputation + m_MuslimsReputation))
                m_Muslims++;
            else if (rng < (m_ChristiansReputation + m_MuslimsReputation + m_JewsReputation))
                m_Jews++;
            else if (rng < (m_ChristiansReputation + m_MuslimsReputation + m_JewsReputation + m_AtheistsReputation))
                m_Atheists++;
            else
                m_OtherReligion++;
        }

        float chri = (100 / m_ChristiansReputation);
        float musl = (100 / m_MuslimsReputation);
        float jews = (100 / m_JewsReputation);
        float athe = (100 / m_AtheistsReputation);
        float othe = (100 / m_OtherReligionReputation);
        float total = chri + musl + jews + athe + othe;

        for (int i = 0; i < m_ResidentsDec; i++)
        {
            

            float rng = Random.Range(0, total);
            if (rng < chri)
                m_Christians--;
            else if (rng < (chri + musl))
                m_Muslims--;
            else if (rng < (chri + musl + jews))
                m_Jews--;
            else if (rng < (chri + musl + jews + athe))
                m_Atheists--;
            else
                m_OtherReligion--;

        }
    }

    void IncrementPlace()
    {
        int totalRep = m_CityReputation + m_VillageReputation;
        for (int i = 0; i < m_ResientsInc; i++)
        {
            int rng = Random.Range(0, totalRep);

            if (rng < m_CityReputation)
                m_City++;
            else
                m_Village++;

        }

        float city = (100 / m_CityReputation);
        float vill = (100 / m_VillageReputation);
        float total = city + vill;

        for (int i = 0; i < m_ResidentsDec; i++)
        {
            float rng = Random.Range(0, total);
            if (rng < city)
                m_City--;
            else
                m_Village--;
        }
    }

    void IncrementOrigin()
    {
        int totalRep = m_LocalsReputation + m_ForeignersReputation;
        for (int i = 0; i < m_ResientsInc; i++)
        {           
            int rng = Random.Range(0, totalRep);

            if (rng < m_LocalsReputation)
                m_Locals++;
            else
                m_Foreigners++;

        }
        float loca = (100 / m_LocalsReputation);
        float fore = (100 / m_ForeignersReputation);
        float total = loca + fore;
        for (int i = 0; i < m_ResidentsDec; i++)
        {
            

            float rng = Random.Range(0, total);
            if (rng < loca)
                m_Locals--;
            else
                m_Foreigners--;
        }
    }
}
