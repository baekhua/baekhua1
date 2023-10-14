using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void OnClickNewGame()
    {
        GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>().PlayBGM(false);
        GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>().PlaySFX(AudioManager.Sfx.Click);
        DataManager._lastScene = SceneManager.GetActiveScene().name;
        LoadingSceneController.LoadScene("baekhua");
    }
    public void OnClickLoad()
    {
        GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>().PlaySFX(AudioManager.Sfx.Click);
        DataManager._lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Select");
    }
    public void OnClickOption()
    {
        GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>().PlaySFX(AudioManager.Sfx.Click);
        DataManager._lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Option");
    }
    public void OnClickQuit()
    {
        GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>().PlaySFX(AudioManager.Sfx.Click);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터의 플레이를 중단시킴
#else
        Application.Quit();
#endif
    }
}
