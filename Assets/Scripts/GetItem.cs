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
                Debug.Log($"�ε��� �ݶ��̴��� �̸��� : {hit.collider.name}");
                Debug.Log($"ItemData�� �̸��� : {itemData._name}, Ÿ���� : {itemData._type}");
                _data.Add(itemData);
                Debug.Log($"���� �������� ������ : {itemData._sprite.name}");
                _inven.gameObject.SetActive(true);
                GenericSingleton<Inventory>.Instance.GetComponent<Inventory>().AddItem(itemData);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

