using UnityEngine;

public class FSM : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform[] _patPoints;
    [SerializeField] float _attackMoveSpeed;
    [SerializeField] float _speed;

    int _patIdx = 0;
    void Start()
    {
        GetComponent<MonsterFSM>().ChangeStateByEnum(MonsterState.Idle);
    }
    public void StartAnim(string AniName)
    {
        GetComponent<Animator>().Play("Idle");
        if(AniName.Equals("Attack"))
        {
            GetComponent<Animator>().SetTrigger("MonsterAttack");
        }
        else if(AniName.Equals("Die"))
        {
            GetComponent<Animator>().SetTrigger("MonsterDie");
        }
        else
        {
            Debug.Log($"State에서 {AniName} 애니메이션을 실행했습니다. ");
        }
    }
    public Transform GetTargetTrans() => _target;
    public Transform GetNowPatPoint() => _patPoints[_patIdx];
    public float GetMoveSpeed() => _speed;
    public float GetAttackMoveSpeed() => _attackMoveSpeed;
    public void AddPatIdx()
    {
        _patIdx++;
        if(_patIdx >= _patPoints.Length) _patIdx = 0;
    }
}
