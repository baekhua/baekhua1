using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : GenericSingleton<PlayerStat>
{
    int _maxHp = 100;
    int _currentHp;
    int _stamina = 100;
    private void Start()
    {
        _currentHp = _maxHp;
    }
    public void MonsterAttack(int damage)
    {
        _currentHp = _currentHp - damage;
        if (_currentHp <= 0) Die();
        //Debug.Log(_hp);
    }
    public void Run(int running)
    {
        _stamina = _stamina - running;
    }
    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("EndingScene");
        Debug.Log("플레이어가 죽었습니다. ");
    }
}
