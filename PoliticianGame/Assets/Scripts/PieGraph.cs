using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PieGraph : MonoBehaviour
{

    public Image m_Wedge;
    public float[] m_Values;
    public Color[] m_Colors;

    public List<Image> m_Wedges = new List<Image>();
    public Transform[] m_Descs;
    private string[] m_DescsText;

    void Start()
    {
        CheckColors();
      //  if(m_Values.Length > 0)
            //MakeGraph();
    }

    void Update()
    {
       // UpdateGraph();
    }

    public void GetData(int[] datas,int total, string[] description)
    {
        m_Values = new float[datas.Length];
        m_DescsText = description;
        for (int i = 0; i < datas.Length; i++)
        {
            m_Values[i] = (float)datas[i];
        }
        CheckColors();
        MakeGraph((float)total);

    }

    public void UpdateData(int[] datas,int total)
    {
        m_Values = new float[datas.Length];
        for (int i = 0; i < datas.Length; i++)
        {
            m_Values[i] = (float)datas[i];
        }
        UpdateGraph();
    }


    private void MakeGraph()
    {
        transform.Find("PLACEHOLDER").gameObject.SetActive(false);


        float total = 0f;
        float zRotation = 0f;
        for (int i = 0; i < m_Values.Length; i++)
        {
            total += m_Values[i];
        }


        for (int i = 0; i < m_Values.Length; i++)
        {
            Image newWedge = Instantiate(m_Wedge) as Image;
            m_Wedges.Add(newWedge);
            newWedge.transform.SetParent(transform, false);
            newWedge.color = m_Colors[i];
            newWedge.fillAmount = m_Values[i] / total;
            newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
            zRotation -= newWedge.fillAmount * 360f;

        }
    }

    void MakeGraph(float total)
    {
        transform.Find("PLACEHOLDER").gameObject.SetActive(false);
        float zRotation = 0f;


        for (int i = 0; i < m_Values.Length; i++)
        {
            Image newWedge = Instantiate(m_Wedge) as Image;
            m_Wedges.Add(newWedge);
            newWedge.transform.SetParent(transform, false);
            newWedge.color = m_Colors[i];
            newWedge.fillAmount = m_Values[i] / total;
            newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
            zRotation -= newWedge.fillAmount * 360f;

        }
        ShowDescription();
    }

    void CheckColors()
    {
        if (m_Colors.Length >= m_Values.Length)
            return;
        else
        {
            Color[] tmp = new Color[m_Values.Length];
            for (int i = 0; i < m_Colors.Length; i++)
            {
                tmp[i] = m_Colors[i];
            }

            for (int i = m_Colors.Length; i < m_Values.Length; i++)
            {
                tmp[i] = GetRandomColor();
            }
            m_Colors = tmp;
        }

    }

    Color GetRandomColor()
    {
        Color newColor = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //Check if already exists
        return newColor;
    }

    public void UpdateGraph()
    {

        float total = 0f;
        float zRotation = 0f;
        for (int i = 0; i < m_Values.Length; i++)
        {
            total += m_Values[i];
        }



        for (int i = 0; i < m_Wedges.Count; i++)
        {
            Image newWedge = m_Wedges[i];
                  
            newWedge.fillAmount = m_Values[i] / total;
            newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
            zRotation -= newWedge.fillAmount * 360f;

        }
    }

    void ShowDescription()
    {
        for (int i = 0; i < m_Wedges.Count; i++)
        {
            m_Descs[i].gameObject.SetActive(true);
            m_Descs[i].GetChild(0).GetComponent<TextMeshProUGUI>().text = m_DescsText[i];
            m_Descs[i].GetChild(1).GetComponent<Image>().color = m_Colors[i];
        }
    }



    
}
