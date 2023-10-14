using System;
using System.Collections.Generic;

public class MonsterFSM : GameObjectFSM
{
    Dictionary<MonsterState, GameObjectFSMState> _state = new Dictionary<MonsterState, GameObjectFSMState>();
    Action _callback;
    private void Awake()
    {
        _state.Add(MonsterState.Idle, new MonsterIdle(gameObject));
        _state.Add(MonsterState.Patrol, new MonsterPatrol(gameObject));
        _state.Add(MonsterState.Attack, new MonsterAttack(gameObject));
        _state.Add(MonsterState.AttackMove, new MonsterAttackMove(gameObject));
        _state.Add(MonsterState.Damage, new MonsterDamage(gameObject));
        _state.Add(MonsterState.Die, new MonsterDie(gameObject));
    }
    public void ChangeStateByEnum(MonsterState type)
    {
        _callback = null;
        ChangeState(_state[type]);
    }
    void AnimCallback()
    {
        _callback?.Invoke();
    }
    public void SetAnimStateCallback(Action action)
    {
        _callback = action;
    }
}
public enum MonsterState
{
    Idle,
    Patrol,
    Attack,
    AttackMove,
    Damage,
    Die,
}