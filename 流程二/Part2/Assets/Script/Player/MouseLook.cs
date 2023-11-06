using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform player;

    private float xRotation = 0f;
    

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 90f);
        transform.localEulerAngles = new Vector3(xRotation, 0f, 0f);


        if (player != null)
        {
            player.Rotate(Vector3.up * mouseX);
        }
        else Debug.Log("相机未连接玩家");
    }
}
