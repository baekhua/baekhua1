using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    public void OnBackButton()
    {
        GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>().PlaySFX(AudioManager.Sfx.Click);
        SceneManager.LoadScene(DataManager._lastScene);
        if(DataManager._lastScene == "baekhua")
        {
            Time.timeScale = 1.0f;
        }
    }
}
