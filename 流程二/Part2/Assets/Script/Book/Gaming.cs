using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaming : MonoBehaviour
{
    public GameObject GameStarter;

    int m_index = 0;
    int count = 0;
    void Awake()
    {
        count = this.transform.childCount;
    }

    
    public void gaming()
    {
        this.gameObject.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.GetChild(m_index).gameObject.SetActive(false);

            m_index = m_index + 1;

            if (m_index >= count)
            {
                m_index = 0;
            }

            this.transform.GetChild(m_index).gameObject.SetActive(true);
        }
    }
}
