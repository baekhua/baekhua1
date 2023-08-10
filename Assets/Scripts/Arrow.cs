using UnityEngine;

public class Arrow : MonoBehaviour
{
    int _damage;
    float _range;
    float _timer = 0f;
    private void Update()
    {
        
    }
    public void SetDamage(int damage)
    {
        _damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster"))
        {
            MonsterStat.Instance.GetComponent<MonsterStat>().TakeDamege(_damage);
        }
    }
    public void ArrowEquip()
    {
        GameObject bow = GameObject.Find("Bow");
        transform.SetParent(bow.transform);
        transform.localPosition = Vector3.zero;
    }
}
