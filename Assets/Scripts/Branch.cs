using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    Transform _branch;

    private void Start()
    {
        _branch = gameObject.GetComponent<Transform>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {

        }
    }
}
