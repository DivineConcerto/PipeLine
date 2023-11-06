using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class OpenBook : MonoBehaviour
{
    public bool enter = false;
    public bool isOpen = false;

    public Event openBook;
    
    // Update is called once per frame
    void Update()
    {
        Open();
    }

    private void OnTriggerEnter(Collider other)
    {
        enter = true;
        Debug.Log(enter);
    }

    private void OnTriggerExit(Collider other)
    {
        Close();
    }

    public void Close()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void Open()
    {
        if (enter && Input.GetMouseButton(0))
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);
            isOpen = true;
        }
        
    }
}
