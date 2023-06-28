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
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        Vector3 v3 = transform.forward * forward * _speed;
        v3 += transform.right * horizontal * _speed;
        v3.y = _rb.velocity.y;
        _rb.velocity = v3;
    }
}
