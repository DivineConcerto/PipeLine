using UnityEngine;
using System.Collections;

public class ListeningAction : MonoBehaviour
{
    public AudioSource listeningTestAudio;
    public Animator Animator;
    private int spacePressCount = 0;

    void Start()
    {
        listeningTestAudio.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressCount++;  // 空格键按下，计数器增加

            if (spacePressCount % 2 != 0)
            {
                StartJumpAndAudio();
            }
            else
            {
                listeningTestAudio.Stop();  // 停止音频
            }
        }
    }

    void StartJumpAndAudio()
    {
        listeningTestAudio.Play();
        
    }

}










