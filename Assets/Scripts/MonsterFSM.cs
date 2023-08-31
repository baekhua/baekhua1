using UnityEngine;

public class MonsterFSM : MonoBehaviour
{

}
public enum MonsterState
{
    Idle,
    Patrol,
    Attack,
    AttackMove,
    Die,
}