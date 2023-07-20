using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] ItemType _type;

    ItemDataList _dataList;
    private void Start()
    {
        _dataList = new ItemDataList();
        _dataList._ItemDataList = new List<ItemData>();        
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            DataToFile();
        }
        if(Input.GetMouseButtonDown(1))
        {
            ReadFile();
        }
    }
    void DataToFile()
    {
        ItemData data = new ItemData(_name, _type);
        _dataList._ItemDataList.Add(data);
        string json = JsonUtility.ToJson(_dataList);

        string path = Application.persistentDataPath + "/ItemDataManager.json";

        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.Write(json);
        }
        Debug.Log(json);
    }
    void ReadFile()
    {
        if(File.Exists(Application.persistentDataPath + "/ItemDataManager.json"))
        {
            string json = "";
            using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/ItemDataManager.json"))
            {
                json = inStream.ReadToEnd();
            }
            if(string.IsNullOrEmpty(json) == false)
            {
                _dataList = JsonUtility.FromJson<ItemDataList>(json);
                foreach(var data in _dataList._ItemDataList)
                {
                    Debug.Log($"name : {data._name}, type : {data._type}");
                }
            }
            else
            {
                Debug.Log("파일은 있지만 내용이 없습니다. ");
            }
        }
        else
        {
            Debug.Log("파일이 없습니다. ");
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

    public ItemData _itemData;
    public ItemData _ItemData { get { return _itemData; } } 

    public ItemData(string name, ItemType type)
    {
        _name = name;
        _type = type;
    }
}
public enum ItemType
{
    Weapon,
    Food,
    Cloth,
    Medicine,
    Consumable,
}
