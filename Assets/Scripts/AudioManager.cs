using UnityEngine;

public class AudioManager : GenericSingleton<AudioManager>
{
    [Header("#BGM")]
    public AudioClip _bgmClip;
    public float _bgmVolume;
    [HideInInspector] public AudioSource _bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] _sfxClips;
    public float _sfxVolume;
    public int _channels;
    [HideInInspector] public AudioSource[] _sfxPlayers;
    int _channelIdx;

    public enum Sfx
    {
        Death,
        Click,
        Monster,
        SnowRun = 4,
        SnowWalk,
    }
    private void Start()
    {
        Init();
        PlayBGM(true);
    }
    void Init()
    {
        // 배경음 플레이어 초기화
        GameObject bgmObj = new GameObject("BGMPlayer");
        bgmObj.transform.parent = transform;
        _bgmPlayer = bgmObj.AddComponent<AudioSource>();
        _bgmPlayer.playOnAwake = false;
        _bgmPlayer.loop = true;
        _bgmPlayer.volume = _bgmVolume;
        _bgmPlayer.clip = _bgmClip;

        // 효과음 플레이어 초기화
        GameObject sfxObj = new GameObject("SFXPlayer");
        sfxObj.transform.parent = transform;
        _sfxPlayers = new AudioSource[_channels];

        for(int i = 0; i < _sfxPlayers.Length; i++)
        {
            _sfxPlayers[i] = sfxObj.AddComponent<AudioSource>();
            _sfxPlayers[i].playOnAwake = false;
            _sfxPlayers[i].volume = _sfxVolume;
        }
    }
    public void PlayBGM(bool isPlay)
    {
        if(isPlay)
        {
            _bgmPlayer.Play();
        }
        else
        {
            _bgmPlayer.Stop();
        }
    }
    public void PlaySFX(Sfx sfx)
    {
        for(int i = 0; i < _sfxPlayers.Length; i++)
        {
            int loopIdx = (i + _channelIdx) / _sfxPlayers.Length;

            if (_sfxPlayers[loopIdx].isPlaying) continue;

            _channelIdx = loopIdx;
            _sfxPlayers[loopIdx].clip = _sfxClips[(int)sfx];
            _sfxPlayers[loopIdx].Play();
            break;
        }
    }
}
