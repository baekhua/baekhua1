using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemType _type;
    public ItemType Type { get { return _type; } }
    ItemData _itemData;

    public void ItemInit(ItemData data)
    {
        _itemData = data;
        gameObject.name = _itemData._name;
    }
    public ItemData GetItem()
    {
        Destroy(gameObject);
        return _itemData;
    }
}
