using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    int _maxHp = 100;
    int _hp;
    int _stamina = 100;

    private void Start()
    {
        GetComponent<PlayerStat>();
    }
    public void WolfAttack(int damage)
    {
        _hp = _maxHp - damage;
        Debug.Log(_hp);
    }
    private void OnCollisionEnter(Collision collision)
    {
        WolfAttack(_hp);
    }
}
