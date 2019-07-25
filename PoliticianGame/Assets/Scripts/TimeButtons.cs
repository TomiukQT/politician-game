using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeButtons : MonoBehaviour
{
    public Button[] m_Buttons;

    private Color m_Normal;
    private Color m_Pressed = Color.red;

    void Awake()
    {
        m_Normal = m_Buttons[0].GetComponent<Image>().color;
        m_Buttons[0].GetComponent<Image>().color = m_Pressed;

    }

    void ChangeAllToNormal()
    {
        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Buttons[i].GetComponent<Image>().color = m_Normal;
        }
    }

    public void ChangeActiveButton(int index)
    {
        ChangeAllToNormal();
        m_Buttons[index].GetComponent<Image>().color = m_Pressed;
    }






}
