using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStart : MonoBehaviour
{
    public Camera playerEyes;
    public Camera game;
    public OpenBook book;
    public Transform gameBook;

    public bool isStart = false;

    public UnityEvent gameStart;

    public float waitTime = 0.75f;
    void Awake()
    {
        book = GetComponent<OpenBook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (book.isOpen)
        {
            StartCoroutine(FadeInGame());
            gameStart.Invoke();
            book.isOpen = false;
        }
            
    }

    void StartGame()
    {
        playerEyes.gameObject.SetActive(false);
        game.gameObject.SetActive(true);
        gameBook.GetChild(0).gameObject.SetActive(true);
        gameBook.GetChild(1).gameObject.SetActive(true);
        gameBook.GetChild(2).gameObject.SetActive(true);

        isStart = true;
        
    }

    IEnumerator FadeInGame()
    {
        yield return new WaitForSeconds(waitTime);
        StartGame();
    }
}
