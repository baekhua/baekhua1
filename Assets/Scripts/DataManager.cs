using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

// �����ϴ� ��
// 1. ������ �����Ͱ� ����
// 2. �����͸� JSON���� ��ȯ
// 3. JSON�� �ܺο� ����

// �ҷ����� ��
// 1. �ܺο� ����� JSON�� ������
// 2. JSON�� ���������·� ��ȯ
// 3. �ҷ��� �����͸� ���

// ���� ���� �ٸ��� ����
[Serializable]
public class PlayerData
{
    // �̸�, �������� ����
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
        #region �̱���
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
