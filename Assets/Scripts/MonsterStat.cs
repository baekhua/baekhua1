using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    float _maxHp = 100;
    float _currentHp = 0;
    float _timer;
    [SerializeField] GameObject _dropItem;
    void Start()
    {
        _currentHp = _maxHp;
    }
    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        Debug.Log($"Damage를 {damage} 만큼 입었습니다 !");

        if (_currentHp <= 0)
        {
            GetComponent<MonsterFSM>().ChangeStateByEnum(MonsterState.Die);
        }
    }
    public void DropAndDestory()
    {
        GameObject temp = Instantiate(_dropItem);
        temp.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
