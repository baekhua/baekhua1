using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
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
            if(hit.distance <= 3f)
            {
                ItemData itemData = hit.collider.GetComponent<Item>().GetItem();
                _data.Add(itemData);
                GenericSingleton<Inventory>.Instance.GetComponent<Inventory>().AddItem(itemData);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

