using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform _cam;
    Rigidbody _rb;
    float _speed = 5f;
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
}
