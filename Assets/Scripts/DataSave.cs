using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] EItemType _type;
    [SerializeField] Sprite _sprite;
    ItemDataList _dataList;
    private void Start()
    {
        _dataList = new ItemDataList();
        _dataList._ItemDataList = new List<ItemData>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            DataToFile();
        }
    }
    void DataToFile()
    {
        ItemData data = new ItemData(_name, _type, _sprite);
        _dataList._ItemDataList.Add(data);
        string json = JsonUtility.ToJson(_dataList);

        string path = Application.persistentDataPath + "/ItemDataManager.json";

        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.Write(json);
        }
        Debug.Log(json);
    }
}
