using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickNewGame()
    {
        DataManager._lastScene = SceneManager.GetActiveScene().name;
        LoadingSceneController.LoadScene("baekhua");
    }
    public void OnClickLoad()
    {
        DataManager._lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Select");
    }
    public void OnClickOption()
    {
        DataManager._lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Option");
    }
    public void OnClickQuit()
    {
        UnityEditor.EditorApplication.isPlaying = false; // 에디터의 플레이를 중단시킴
    }
}
