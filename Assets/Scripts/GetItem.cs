using UnityEngine;

public class GetItem : MonoBehaviour
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    float distance = Vector3.Distance(transform.position, other.transform.position);
    //    if (other.CompareTag("Item"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.F))
    //        {
    //            // 인벤토리에 들어감
    //            _branch.SetActive(false);
    //        }
    //    }
    //}
    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (_branch != null)
    //        {
    //            _branch = null;
    //        }
    //    }
    //}
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ShootRay();
        }

    }
    void ShootRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool colResult = Physics.Raycast(ray, out hit);
        if(colResult == true && hit.collider.CompareTag("Item"))
        {
            if(hit.distance <= 3f)
            {
                Debug.DrawRay(transform.position, transform.forward * 5, Color.red, 5f);
                Debug.Log(hit.distance);
                //hit.collider.gameObject.SetActive(false);
                Destroy(hit.collider.gameObject);
            }
            GenericSingleton<Inventory>.Instance.GetComponent<Inventory>().AddItem(hit.collider.GetComponent<Item>().GetItem());
        }
    }
}
//class ItemObj
//{
//    public string _name;
//    public EItemType _etype;
//    public Branch _branch;

//    public ItemObj(string name, EItemType etype)
//    {
//        _name = name;
//        _etype = etype;
//    }
//    //void SetBranch(Branch branch)
//    //{
//    //    _branch = branch;
//    //}
//    public void Equip()
//    {
//        GameObject playerHand = GameObject.Find("RightHand");
//        _branch.transform.SetParent(playerHand.transform);
//        _branch.transform.localPosition = Vector3.zero;
//    }
//}
//public enum EItemType
//{
//    Branch,
//}

