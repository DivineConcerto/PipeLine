using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public PlayerControl controller;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<PlayerControl>();
    }

    void Update()
    {
        GroundCheck();
        Moving();
    }

    void Moving()
    {
        
        if(rb.velocity.magnitude > 0.2f)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    void GroundCheck()
    {
        if(controller.isGround)
        {
            animator.SetBool("Grounded", true);
        }
    }
}
