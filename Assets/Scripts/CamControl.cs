using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] Transform _player;
    float rotX;
    float rotY;
    float minYAngle = -80f;
    float maxYAngle = 80f;
    private void Update()
    {
        rotX -= Input.GetAxis("Mouse Y");
        rotY += Input.GetAxis("Mouse X");

        rotX = Mathf.Clamp(rotX, minYAngle, maxYAngle);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        transform.position = new Vector3(_player.position.x, _player.position.y, _player.position.z);
    }
}
