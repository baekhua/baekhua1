using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : GenericSingleton<Inventory>
{
    [SerializeField] GameObject _UIItems;
    [SerializeField] Transform _content;
    [SerializeField] Sprite[] _sprites;
    List<ItemData> _items;
    List<GameObject> _itemSlot;
    public void AddItem(ItemData data)
    {
        GameObject temp = Instantiate(_UIItems, _content);
        _items.Add(data);
        _itemSlot.Add(temp);
        
        for(int i = 0; i < _items.Count; i++)
        {
            ItemData itemData = _items[i];
            _itemSlot[i].GetComponent<ItemSlot>().Init(itemData, itemData._sprite);
        }
    }
    public void RemoveItem()
    {

    }
}
