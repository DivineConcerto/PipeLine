using UnityEngine;
using System.Collections;


public class ListeningAction : MonoBehaviour
{
    public AudioSource listeningTestAudio;
    public Animator Animator;

    void Start()
    {
        listeningTestAudio.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartJumpAndAudio();
        }
    }

    void StartJumpAndAudio()
    {
        listeningTestAudio.Play();
        StartCoroutine(TriggerJumps());
    }

    IEnumerator TriggerJumps()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, listeningTestAudio.clip.length / 5));  // 根据音频的长度随机等待
            Animator.SetTrigger("doJump");
        }
    }
}







