using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _tvPos;
    [SerializeField] Transform _realCam;
    float rotX;
    float rotY;

    Vector3 _fvPos;
    private void Start()
    {
        _fvPos = _realCam.localPosition;
    }
    private void Update()
    {
        rotX -= Input.GetAxis("Mouse Y");
        rotY += Input.GetAxis("Mouse X");

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        transform.position = new Vector3(_player.position.x, _fvPos.y, _player.position.z);
    }
}
