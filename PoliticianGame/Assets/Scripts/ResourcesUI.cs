using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResourcesUI : MonoBehaviour
{

    public GameObject[] m_Sliders;

    private Resources m_Resources;


    private void Awake()
    {
        m_Resources = transform.GetComponent<Resources>();
    }

   
    
    void Update()
    {
        UpdateAgeSliders();
    }

    void UpdateAgeSliders()
    {
        m_Sliders[0].GetComponent<Slider>().value = m_Resources.m_AdultsReputation;
        m_Sliders[1].GetComponent<Slider>().value = m_Resources.m_YoungsReputation;
        m_Sliders[2].GetComponent<Slider>().value = m_Resources.m_PensionersReputation;
    }
}
