using UnityEngine;

public class ItemType : MonoBehaviour
{
    [SerializeField] EItemType _type;
    public EItemType Type { get { return _type; } }
    public ItemData _itemData;
    private void Start()
    {

    }
    public void ItemInit(ItemData data)
    {
        _itemData = data;
        _type = data._type;
        Debug.Log($"저장된 데이터의 이름은 : {_itemData._name}");
        gameObject.name = _itemData._name;
        Debug.Log($"ItemInit 되었습니다.");
    }
}
