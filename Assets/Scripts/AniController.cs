using UnityEngine;

public class AniController : MonoBehaviour
{
    [SerializeField] Animator _anim;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _anim.SetTrigger("Run");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _anim.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _anim.SetTrigger("Attack1");
        }
    }
}
