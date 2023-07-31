using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemType _type;
    public ItemType Type { get { return _type; } }
    ItemData _itemData;
    private void Start()
    {

    }
    public void ItemInit(ItemData data)
    {
        _itemData = data;
        gameObject.name = _itemData._name;
    }
    public ItemData GetItem()
    {
        return _itemData;
    }
}
