using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text _name;
    public Text _level;
    public Text _coin;

    [SerializeField] GameObject[] _item;
    void Start()
    {
        _name.text += DataManager.instance._nowPlayer._name;
        _level.text += DataManager.instance._nowPlayer._level.ToString();
        _coin.text += DataManager.instance._nowPlayer._coin.ToString();
        ItemSetting(DataManager.instance._nowPlayer._weapon);
    }
    public void LevelUp()
    {
        DataManager.instance._nowPlayer._level++;
        _level.text = "레벨 : " + DataManager.instance._nowPlayer._level.ToString();
    }
    public void CoinUp()
    {
        DataManager.instance._nowPlayer._coin += 100;
        _coin.text = "코인 : " + DataManager.instance._nowPlayer._coin.ToString();
    }
    public void Save()
    {
        DataManager.instance.SaveData();
    }
    public void ItemSetting(int number)
    {
        for(int i = 0; i < _item.Length; i++)
        {
            if(number == i)
            {
                _item[i].SetActive(true);
                DataManager.instance._nowPlayer._weapon = number;
            }
            else
            {
                _item[i].SetActive(false);
            }
        }
    }
}
