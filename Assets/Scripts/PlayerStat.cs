using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    int _maxHp = 100;
    int _hp;
    int _stamina = 100;
    ItemObj _itemObj;
    [SerializeField] Transform _branchSpawner;

    private void Start()
    {
        GetComponent<PlayerStat>();
        _itemObj = GetComponent<ItemObj>();

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            var branch = _branchSpawner;
            foreach (var vars in branch)
            {
                float mindDistance = Vector3.Distance(transform.position, branch.position);
                if(mindDistance < 1f)
                {
                     // �÷��̾�� branch�� �� ���̰��� 1 �̸��� �ֵ��� ���� �����ؾ���.
                }
            }
        }
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
