using UnityEngine;

public class Item : ItemDataManager
{
    string _name = "";
    Sprite _sprite;
    void Start()
    {
        
    }
    public void Init(ItemData data)
    {
        _itemData = data;
        _name = data._name;
        _sprite = data._sprite;
    }
    public void ItemEffect()
    {
        GenericSingleton<PlayerStat>.Instance.GetComponent<PlayerStat>().IncHp(20);
        Invoke("DestroyItem", 0.01f);
    }
    void DestroyItem()
    {
        Destroy(gameObject);
    }
}
