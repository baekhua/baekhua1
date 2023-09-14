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

    GameObject _makedArrow;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
        if (Input.GetMouseButtonDown(0) && !_isEquipped)
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
        _makedArrow = Instantiate(_arrowPrefab);
        _makedArrow.transform.position = transform.position;
        //_makedArrow.GetComponent<Rigidbody>().isKinematic = true;
        _makedArrow.GetComponent<Arrow>().SetDamage(_attackDamage);
        //_makedArrow.GetComponent<BoxCollider>().isTrigger = true;
        _isEquipped = true;
    }
    public void Equip()
    {
        GameObject heroHand = GameObject.Find("RightHand");
        transform.SetParent(heroHand.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    void ShootArrow()
    {
        //_makedArrow.transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        //_makedArrow.GetComponent<Rigidbody>().isKinematic = false;
        //_makedArrow.GetComponent<BoxCollider>().isTrigger = false;
        //_makedArrow.GetComponent<Rigidbody>().AddForce(transform.forward * _range, ForceMode.Impulse);
        //_isEquipped = false;
        // 화살 발사 방향과 힘 설정
        Vector3 shootDirection = transform.forward;
        _makedArrow.GetComponent<Arrow>().Shoot(shootDirection, _range);

        // 장전 상태 해제
        _isEquipped = false;

        // 화살 재활용을 위해 ResetArrow 함수 호출
    }
}