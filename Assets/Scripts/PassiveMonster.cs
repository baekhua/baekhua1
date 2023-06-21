using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PassiveMonster : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _monster;
    float _speed = 4;
    void Update()
    {
        if (_monster != null)
        {
            if (Vector3.Distance(_player.position, _monster.position) < 50)
            {
                // �ݵ�� 50 �ȿ� �÷��̾ ���;� �־����°� �ƴ϶�
                // ������ �þ� �ȿ� ������ �� �־�������.
                RunawayPlayer();
            }
        }
    }
    void RunawayPlayer()
    {
        Vector3 moveVector = (_player.position - _monster.position);
        Vector3 dirVector = moveVector.normalized;
        Vector3 lastVector = dirVector * _speed;
        _monster.position -= lastVector * Time.deltaTime;
    }
}
