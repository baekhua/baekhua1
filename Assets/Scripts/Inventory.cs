using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : GenericSingleton<Inventory>
{
    [SerializeField] GameObject _UIItems;
    [SerializeField] Transform _content;
    [SerializeField] Sprite[] _sprites;
    List<ItemData> _items = new List<ItemData>();
    List<GameObject> _itemSlots = new List<GameObject>();

    public void AddItem(ItemData data)
    {
        GameObject temp = Instantiate(_UIItems, _content);
        _items.Add(data);
        _itemSlots.Add(temp);

        for (int i = 0; i < _items.Count; i++)
        {
            ItemData itemData = _items[i];
            Debug.Log($"해당 아이템 슬롯은 : {_itemSlots[i].name}");
            if (_itemSlots[i].GetComponent<ItemSlot>() != null)
            {
                Debug.Log($"_items리스트의 이름은 : {_items[i]._name}");
                _itemSlots[i].GetComponent<ItemSlot>().Init(_items[i], _sprites[0]);
            }
            else
            {
                Debug.Log("null입니다.");
            }
        }
    }
    public void RemoveItem(GameObject itemData)
    {
        _items.Remove(itemData.GetComponent<ItemSlot>()._itemData);
        _itemSlots.Remove(itemData);
    }
}
