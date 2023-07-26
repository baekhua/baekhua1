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
                //Debug.DrawRay(transform.position, transform.forward * 5, Color.red, 5f);
                //Debug.Log(hit.distance);
                ItemData itemData = hit.collider.GetComponent<Item>().GetItem();
                _data.Add(itemData);
                Inventory.Instance.GetComponent<Inventory>().AddItem(itemData);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

