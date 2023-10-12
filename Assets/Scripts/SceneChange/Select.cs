using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    [SerializeField] GameObject _creat;
    [SerializeField] Text[] _slotText;
    [SerializeField] Text _newPlayerName;

    bool[] _saveFile = new bool[3];
    // ������ 3���ε� ��� �˸°� �ҷ�������?
    private void Start()
    {
        // ���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�
        
        for(int i = 0; i < 3; i++)
        {
            if(File.Exists(DataManager.instance._path + $"{i}"))
            {
                _saveFile[i] = true;
                DataManager.instance._nowSlot = i;
                DataManager.instance.LoadData();
                _slotText[i].text = DataManager.instance._nowPlayer._name;
            }
            else
            {
                _slotText[i].text = "�������";
            }
        }
        DataManager.instance.DataClear();
    }
    public void Slot(int number)
    {
        GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>().PlaySFX(AudioManager.Sfx.Click);
        DataManager.instance._nowSlot = number;

        if (_saveFile[number])
        {
            DataManager.instance.LoadData();
            GoGame();
        }
        else
        {
            CreatSlot();
        }
    }
    public void CreatSlot()
    {
        _creat.gameObject.SetActive(true);
    }
    public void GoGame()
    {
        GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>().PlaySFX(AudioManager.Sfx.Click);
        if (!_saveFile[DataManager.instance._nowSlot])
        {
            DataManager.instance._nowPlayer._name = _newPlayerName.text;
            DataManager.instance.SaveData();
            Debug.Log("GoGame�� ����Ǿ����ϴ�.");
        }
        LoadingSceneController.LoadScene("baekhua");
    }
    public void BackScene()
    {
        GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>().PlaySFX(AudioManager.Sfx.Click);
        SceneManager.LoadScene("TitleScene");
    }
}
