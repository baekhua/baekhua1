using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    [SerializeField] GameObject[] _items;
    protected GameObject _itemGameObj;
    protected ItemData _itemData;
    ItemDataList _dataList;
    private void Awake()
    {
        _dataList = new ItemDataList();
        _dataList._ItemDataList = new List<ItemData>();
        ReadFile();
    }
    void ReadFile()
    {
        TextAsset dataFile = Resources.Load("ItemDataManager") as TextAsset;
        string dataJson = dataFile.text;
        if (string.IsNullOrEmpty(dataJson) == false)
        {
            _dataList = JsonUtility.FromJson<ItemDataList>(dataJson);
            foreach (var data in _dataList._ItemDataList)
            {
                Debug.Log($"name : {data._name}, type : {data._type}");
            }
            ItemSpawn();
        }
        else
        {
            Debug.Log("파일은 있지만 내용이 없습니다. ");
        }
    }
    public GameObject SpawnItem(ItemData itemData)
    {
        foreach(var item in _items)
        {
            EItemType iType = item.GetComponent<ItemType>().Type;
            GameObject temp = null;
            if (iType == itemData._type)
            {
                Debug.Log($"iType의 타입은 : {iType}, 비교할 데이터의 타입은 : {itemData._type}");
                temp = Instantiate(item);
                Debug.Log($"생성한 아이템의 이름은 : {temp.name}");
                temp.name = itemData._name;
                Debug.Log($"다시 할당된 아이템의 이름은 : {temp.name}");
                temp.GetComponent<Item>().Init(itemData);
                temp.GetComponent<ItemType>().ItemInit(itemData);
            }
            return temp;
        }
        return null;
    }
    public GameObject ItemSpawn()
    {
        GameObject temp = null;
        foreach (var data in _dataList._ItemDataList)
        {
            temp = SpawnItem(data);
            if (temp == null) continue;
            temp.name = data._name;
        }
        return temp;
    }
    public void UseItem(EItemType iType)
    {
        if(iType == EItemType.Food)
        {
            _itemGameObj.GetComponent<Item>().ItemEffect();
        }
    }
    public void SetItemGameObject(GameObject item) => _itemGameObj = item;
}
[Serializable]
public class ItemDataList
{
    public List<ItemData> _ItemDataList;
}
[Serializable]
public class ItemData
{
    public string _name;
    public EItemType _type;
    public Sprite _sprite;
    public ItemData(string name, EItemType type, Sprite sprite)
    {
        _name = name;
        _type = type;
        _sprite = sprite;
    }
}
public enum EItemType
{
    Weapon,
    Food,
    Cloth,
    Medicine,
    Other,
}
