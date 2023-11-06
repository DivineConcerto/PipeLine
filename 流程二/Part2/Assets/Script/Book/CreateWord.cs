using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreateWord : MonoBehaviour
{
    public GameObject[] texts;
    private GameObject node;

    public UnityEvent endLevel;
    private void Update()
    {
        Right();
        Wrong();
    }
    public void createWords()
    {
        if (texts.Length != 0)
        {
            node = Object.Instantiate(texts[Random.Range(0, texts.Length)], this.transform);
            node.transform.position = transform.position + new Vector3(Random.Range(-0.25f, 0.25f), 0, Random.Range(-0.05f, 0.05f));
            node.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
    public void wordsShaking()
    {
        InvokeRepeating("createWords", 0.5f, 2f);
    }
    public void stopShaking()
    {
        CancelInvoke("createWords");
    }
    public void Right()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            stopShaking();
            this.transform.GetChild(2).gameObject.SetActive(true);
            StartCoroutine(WatingForRight());
        }
    }
    public void Wrong()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            this.transform.GetChild(3).gameObject.SetActive(true);
            StartCoroutine(WatingForWrong());
        }
        
    }

    IEnumerator WatingForRight()
    {
        yield return new WaitForSeconds(3f);
        endLevel?.Invoke();
        StopCoroutine(WatingForWrong());
    }

    IEnumerator WatingForWrong()
    {
        yield return new WaitForSeconds(3f);
        this.transform.GetChild(3).gameObject.SetActive(false);
    }
}
