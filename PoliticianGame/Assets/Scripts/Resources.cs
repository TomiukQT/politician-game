using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    #region PEOPLE

    public int m_Residents = 10000000; //10M

    //AGE
    public int m_Youngs;
    public int m_Adults;
    public int m_Pensioners;

    //EDUCATION
    public int m_Elementary;
    public int m_HighSchool;
    public int m_University;

    //RELIGION
    public int m_Atheists;
    public int m_Christians;
    public int m_Jews;
    public int m_Muslims;
    public int m_OtherReligion;

    //LIVING PLACE
    public int m_City;
    public int m_Village;

    //LOCAL/FOREIGNER
    public int m_Locals;
    public int m_Foreigners;



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
}
