using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _inGameOption;
    [SerializeField] GameObject _inventory;
    bool _cursorLock = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _cursorLock = true;
        }
    }
    public void OnInGameOption()
    {
        Time.timeScale = 0f;
        _inGameOption.SetActive(true);
    }
    public void OptionBackBtn()
    {
        Time.timeScale = 1f;
        _inGameOption.SetActive(false);
        if(_cursorLock == true)
        {
            Cursor.lockState= CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void OnInvenBtn()
    {
        Time.timeScale = 0f;
        _inventory.SetActive(true);
    }
    public void InvenBackBtn()
    {
        Time.timeScale = 1f;
        _inventory.SetActive(false);
        if (_cursorLock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
