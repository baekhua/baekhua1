using UnityEngine;

public class Arrow : MonoBehaviour
{
    int _damage;
    float _range;
    float _timer = 0f;
    Rigidbody _rig;
    private void Awake()
    {
        _rig = GetComponent<Rigidbody>();
    }
    public void SetDamage(int damage)
    {
        _damage = damage;
    }
    public void Shoot(Vector3 dir, float force)
    {
        _rig.velocity = dir.normalized * force;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Monster"))
    //    {
    //        MonsterStat.Instance.GetComponent<MonsterStat>().TakeDamege(_damage);
    //    }
    //}
    public void ArrowEquip()
    {
        GameObject bow = GameObject.Find("Bow");
        transform.SetParent(bow.transform);
        transform.localPosition = Vector3.zero;
    }
}
