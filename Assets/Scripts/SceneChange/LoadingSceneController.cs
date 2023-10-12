using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    static string _nextScene;
    [SerializeField] Image _progressBar;
    public static void LoadScene(string sceneName)
    {
        _nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    private void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }
    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(_nextScene);
        op.allowSceneActivation = false; // 씬을 비동기 로딩할 때, 로드가 끝난 뒤에 바로 씬을 불러올 것인지 여부
                                         // false는 90% 까지 로드한 뒤 true로 바뀌면 남은 10%를 로드하고 씬을 불러옴
        float timer = 0f;
        while(!op.isDone) // 씬 로딩이 끝나지 않았을 때
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                _progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                _progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(_progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
