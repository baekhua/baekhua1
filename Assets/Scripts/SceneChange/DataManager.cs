using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class PlayerData
{
    public string _name;
    public int _level = 1;
    public int _coin = 100;
    public int _weapon = -1;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public static string _lastScene;
    
    [HideInInspector] public int _nowSlot;
    [HideInInspector] public string _path;
    [HideInInspector] public PlayerData _nowPlayer = new PlayerData();

    private void Awake()
    {
        #region ΩÃ±€≈Ê
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
