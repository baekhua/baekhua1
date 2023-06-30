using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField] GameObject _branch;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Item"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.F))
    //        {
    //            // 인벤토리에 들어감
    //            _branch.SetActive(false);
    //        }
        //}
    //}
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_branch != null)
            {
                _branch.SetActive(false);
            }
        }
    }
}
