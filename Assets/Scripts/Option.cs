using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnBackButton()
    {
        SceneManager.LoadScene(DataManager._lastScene);
        if(DataManager._lastScene == "baekhua")
        {
            Time.timeScale = 1.0f;
        }
    }
}
