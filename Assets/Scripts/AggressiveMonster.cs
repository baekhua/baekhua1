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
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("플레이어에게 데미지가 들어갑니다.");
        }
    }
    void Update()
    {
        if(_monster != null)
        {
            if(Vector3.Distance(_player.position, _monster.position) <= 3)
            {
                Invoke("Attack", 1f);
            }
            else if(Vector3.Distance(_player.position, _monster.position) < 50)
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
        // 1초마다 플레이어에게 공격할 행동
        // 공격은 콜라이더로 하기 때문에
        // 몬스터의 트랜스폼 포지션과 플레이어의 트랜스폼 포지션의 거리가 1이 되었다가
        // 다시 원래 위치가 되는 로직
    }
}
