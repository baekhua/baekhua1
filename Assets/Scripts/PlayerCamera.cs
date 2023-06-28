using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform _cam;
    [SerializeField] float _speed;

    private void FixedUpdate()
    {
        Vector3 camRot = new Vector3(_cam.transform.forward.x, 0, _cam.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(camRot);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 v3 = (transform.forward * y + transform.right * x) * _speed;
        v3.y = GetComponent<Rigidbody>().velocity.y;
        GetComponent<Rigidbody>().velocity = v3;
    }
}
