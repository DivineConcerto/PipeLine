using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 1.0f;

    Vector3 velocity;
    public bool isGround;

    public Transform groundCheck;
    private float groundDistance = 0.2f;
    public LayerMask groundMask;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

}
