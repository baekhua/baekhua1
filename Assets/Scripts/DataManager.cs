using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

// 저장하는 법
// 1. 저장할 데이터가 존재
// 2. 데이터를 JSON으로 변환
// 3. JSON을 외부에 저장

// 불러오는 법
// 1. 외부에 저장된 JSON을 가져옴
// 2. JSON을 데이터형태로 변환
// 3. 불러온 데이터를 사용

// 슬롯 별로 다르게 저장
[Serializable]
public class PlayerData
{
    // 이름, 착용중인 무기
    public string _name;
    public int _level = 1;
    public int _coin = 100;
    public int _weapon = -1;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    public PlayerData _nowPlayer = new PlayerData();
    public int _nowSlot;
    public string _path;
    public static string _lastScene;

    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion
        _path = Application.persistentDataPath + "/Save";
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(_nowPlayer);
        File.WriteAllText( _path + _nowSlot.ToString(), json );
    }
    public void LoadData()
    {
        string json = File.ReadAllText(_path + _nowSlot.ToString());
        _nowPlayer = JsonUtility.FromJson<PlayerData>( json );
    }
    public void DataClear()
    {
        _nowSlot = -1;
        _nowPlayer = new PlayerData();
    }
}
