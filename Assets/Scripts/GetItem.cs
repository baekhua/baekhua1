using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField] GameObject _inven;
    List<ItemData> _data;
    private void Start()
    {
        _data = new List<ItemData>();
    }
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
            if(Vector3.Distance(gameObject.transform.position, hit.transform.position) <= 5f)
            {
                ItemData itemData = hit.collider.GetComponent<ItemType>()._itemData;
                Debug.Log($"부딪힌 콜라이더의 이름은 : {hit.collider.name}");
                Debug.Log($"ItemData의 이름은 : {itemData._name}, 타입은 : {itemData._type}");
                _data.Add(itemData);
                Debug.Log($"먹을 아이템의 정보는 : {itemData._sprite.name}");
                _inven.gameObject.SetActive(true);
                GenericSingleton<Inventory>.Instance.GetComponent<Inventory>().AddItem(itemData);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

