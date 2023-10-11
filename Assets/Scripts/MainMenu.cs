using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickNewGame()
    {
        LoadingSceneController.LoadScene("Scene2");
    }
    public void OnClickLoad()
    {
        SceneManager.LoadScene("Select");
    }
    public void OnClickOption()
    {

    }
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터의 플레이를 중단시킴
#else
        Application.Quit();
#endif
    }
}
