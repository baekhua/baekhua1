using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] ItemType _type;

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
        }
        else
        {
            Debug.Log("파일은 있지만 내용이 없습니다. ");
        }
    }
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
    public ItemType _type;
    public Sprite _sprite;
    public ItemData(string name, ItemType type, Sprite sprite)
    {
        _name = name;
        _type = type;
        _sprite = sprite;
    }
}
public enum ItemType
{
    Weapon,
    Food,
    Cloth,
    Medicine,
    Other,
}
