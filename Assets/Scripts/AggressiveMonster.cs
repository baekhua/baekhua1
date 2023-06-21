using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveMonster : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _monster;
    float _speed = 6;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Attack();
            Debug.Log("플레이어에게 데미지가 들어갑니다.");
        }
    }
    void Update()
    {
        if(_monster != null)
        {
            if(Vector3.Distance(_player.position, _monster.position) < 50)
            {
                FollowPlayer();
            }
        }
        
        // 시야 안에 플레이어가 감지되면 플레이어를 따라온다.
    }
    void FollowPlayer()
    {
        Vector3 moveVector = (_player.position - _monster.position);
        Vector3 dirVector = moveVector.normalized;
        Vector3 lastVector = dirVector * _speed;
        _monster.position = _monster.position + lastVector * Time.deltaTime;
        _monster.LookAt(_player);
    }
    void Attack()
    {
        
    }
}
