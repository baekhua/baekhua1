using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField] Transform _rightHand;
    Transform _branch;

    private void Start()
    {
        _branch = gameObject.GetComponent<Transform>();
    }
}
