using UnityEngine;

public class ControlSky : MonoBehaviour
{
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
    }
}
