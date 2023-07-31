using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] GameObject _arrowPrefab;

    string _name = "Bow";
    float _weight = 1.5f;
    int _attackDamage = 1;
    float _range = 10f;
    float _reloadTime = 1.5f;
    bool _isReloading = false;
    bool _isEquipped = false;

    private void Update()
    {
        if(Input.GetMouseButton(0) && !_isEquipped)
        {
            PullArrow();
        }
        if(Input.GetMouseButtonUp(0))
        {
            ShootArrow();
        }
    }
    void PullArrow()
    {
        GameObject arrowPrefab = Instantiate(_arrowPrefab);
        arrowPrefab.GetComponent<Arrow>().SetDamage(_attackDamage);
        arrowPrefab.transform.position = transform.position;
        _isEquipped = true;
        //arrowPrefab.GetComponent<Rigidbody>().velocity = transform.forward * _range;
    }
    public void Equip()
    {
        GameObject heroHand = GameObject.Find("RightHand");
        transform.SetParent(heroHand.transform);
        transform.localPosition = Vector3.zero;
    }
    void ShootArrow()
    {
        _arrowPrefab.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Force);
        _isEquipped = false;
    }
}