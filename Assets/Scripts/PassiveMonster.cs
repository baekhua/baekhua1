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
                // 반드시 50 안에 플레이어가 들어와야 멀어지는게 아니라
                // 몬스터의 시야 안에 들어왔을 때 멀어져야함.
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
