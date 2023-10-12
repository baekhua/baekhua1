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
        op.allowSceneActivation = false; // ���� �񵿱� �ε��� ��, �ε尡 ���� �ڿ� �ٷ� ���� �ҷ��� ������ ����
                                         // false�� 90% ���� �ε��� �� true�� �ٲ�� ���� 10%�� �ε��ϰ� ���� �ҷ���
        float timer = 0f;
        while(!op.isDone) // �� �ε��� ������ �ʾ��� ��
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
