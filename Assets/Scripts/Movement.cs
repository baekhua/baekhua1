using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody _rb;
    float _speed = 5;
    float rotX = 0f;
    float rotY = 0f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        Vector3 v3 = transform.forward * forward * _speed;
        v3 += transform.right * horizontal * _speed;
        _rb.velocity = v3;
    }
    private void Update()
    {
        rotX -= Input.GetAxis("Mouse Y");
        rotY += Input.GetAxis("Mouse X");
        RotateQuaternion();
    }
    void RotateQuaternion()
    {
        transform.rotation = Quaternion.Euler(rotX, 0f, 0f);
        Camera.main.transform.rotation = Quaternion.Euler(0f, rotY, 0f);
    }
}
