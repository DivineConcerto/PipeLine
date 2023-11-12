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
            spacePressCount++;  // �ո�����£�����������

            if (spacePressCount % 2 != 0)
            {
                StartJumpAndAudio();
            }
            else
            {
                listeningTestAudio.Stop();  // ֹͣ��Ƶ
            }
        }
    }

    void StartJumpAndAudio()
    {
        listeningTestAudio.Play();
        
    }

}










