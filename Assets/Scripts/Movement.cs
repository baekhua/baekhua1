using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform _cam;
    [SerializeField] float _speed;
    Rigidbody _rb;
    bool _isSlope = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        Vector3 v3 = transform.forward * forward * _speed;
        v3 += transform.right * horizontal * _speed;
        v3.y = _rb.velocity.y;
        _rb.velocity = v3;

        Vector3 camRot = new Vector3(_cam.transform.forward.x, 0, _cam.transform.forward.z);
        _rb.transform.rotation = Quaternion.LookRotation(camRot);
    }
    private void Update()
    {
        RayNormal();
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 5f;
            PlayerStat.Instance.GetComponent<PlayerStat>().Run((int)_speed);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = 2f;
        }
    }
    void RayNormal()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, -transform.up, out hit, 2f))
        {
            if (Mathf.Abs(Vector3.Angle(Vector3.up, hit.normal)) > 40) // 충돌면의 기울기가 40도 이상일 때
            {
                //Debug.Log("충돌면의 기울기 : " + Vector3.Angle(Vector3.up, hit.normal));
                Vector3 slopeForce = Vector3.ProjectOnPlane(Physics.gravity, hit.normal).normalized * 0.5f;
                GetComponent<Rigidbody>().AddForce(slopeForce, ForceMode.Impulse);
                //Debug.Log("slope force : " + slopeForce);
                _isSlope = true;
                Invoke("ResetSloped", 0.1f);
            }
        }
    }
    void ResetSloped()
    {
        _isSlope = false;
    }
}

