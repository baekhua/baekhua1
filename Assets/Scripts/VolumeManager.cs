using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    AudioSource _musicSource;
    AudioSource[] _sfxSources;
    private void Start()
    {
        _musicSource = GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>()._bgmPlayer;
        _sfxSources = GenericSingleton<AudioManager>.Instance.GetComponent<AudioManager>()._sfxPlayers;
    }
    public void SetMusicVolume(float volume)
    {
        _musicSource.volume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        //_sfxSources.volume = volume;
    }
}
