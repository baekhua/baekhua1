//using System.IO;
//using UnityEngine;

//public class ItemSpawner : GenericSingleton<ItemSpawner>
//{
//    [SerializeField] GameObject[] _items;
//    Transform[] _points;
//    ItemDataList _dataList;
//    public void SpawnerInit(Transform[] points)
//    {
//        _points = points;
//        _dataList = new ItemDataList();
//        ItemLoad();
//    }
//    void ItemLoad()
//    {
//        if(File.Exists(Application.persistentDataPath + "/ItemDataManager.json"))
//        {
//            string json = "";
//            using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/ItemDataManager.json"))
//            {
//                json = inStream.ReadToEnd();
//            }
//            if(string.IsNullOrEmpty(json) == false)
//            {
//                _dataList = JsonUtility.FromJson<ItemDataList>(json);
//                SpawnItems();
//            }
//            else
//            {
//                Debug.Log("내용이 없습니다. ");
//            }
//        }
//        else
//        {
//            Debug.Log("파일이 없습니다. ");
//        }
//    }
//    void SpawnItems()
//    {
//        int i = 0;
//        foreach(var data in _dataList._ItemDataList)
//        {
//            foreach(var item in _items)
//            {
//                if (data._type == item.GetComponent<Item>().Type)
//                {
//                    GameObject temp = Instantiate(item);
//                    temp.GetComponent<Item>().ItemInit(data);
//                    temp.transform.position = _points[i].transform.position;
//                    i++;
//                    break;
//                }
//            }
//        }
//    }
//}
