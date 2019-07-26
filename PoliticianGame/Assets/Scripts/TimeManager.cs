using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    //UI
    public TextMeshProUGUI m_DateText;
    
  

    public int m_Days = 1;
    private string[] m_DaysAsString = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
    private int[] m_DaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    private int m_DayInWeek = 0;

    public int m_Months = 1;
    private string[] m_MonthsAsString  = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

    public int m_Years = 1990;

    private float m_Timer = 0f;
    private float m_TimeConstant = 1f;

    public static TimeManager m_Singleton;

    public static TimeManager SingleTon()
    {
        return m_Singleton;
    }

    void Awake()
    {
        m_Singleton = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {

        TimerUpdate();
    }

    void TimerUpdate()
    {
        m_Timer += Time.deltaTime * m_TimeConstant;
        if(m_Timer >= 1f )
        {
            m_Timer = 0f;
            Tick();
        }
    }

    void Tick()
    {
        m_Days++;
        m_DayInWeek++;
        if (m_DayInWeek >= 7)
        {
            m_DayInWeek = 0;
        }
        if (m_Days > m_DaysInMonth[m_Months - 1])
        {
            m_Days = 1;
            m_Months++;
        }
        if (m_Months >= 13)
        {
            m_Months = 1;
            m_Years++;
        }

        UpdateUI();
    }

    public void ChangeTimeConstant(float newConstant)
    {
        m_TimeConstant = newConstant;
    }

    void UpdateUI()
    {
        m_DateText.text = string.Format("{0} {1}. {2} {3}", m_DaysAsString[m_DayInWeek], m_Days, m_MonthsAsString[m_Months - 1], m_Years);
    }

    public float GetTimeConst()
    {
        return m_TimeConstant;
    }
        
}
