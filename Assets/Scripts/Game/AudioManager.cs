using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] public Sound[] sfxSoundList;
    public Sound music;
    private Sound _selectedSFX;
    public AudioMixer mixer;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;
    private bool _toggle;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        _toggle = true;
        if (PlayerPrefs.HasKey("BGM"))
        {
            mixer.SetFloat("SFX", PlayerPrefs.GetFloat("BGM"));
        }
        if (PlayerPrefs.HasKey("SFX"))
        {
            mixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
        }
        PlayMusic();
    }
    public void PlayMusic()
    {
        _musicSource.clip = music.clip;
        _musicSource.loop = true;
        _musicSource.Play();
    }
    public void PlaySFX(string name)
    {
        foreach (Sound clip in sfxSoundList)
        {
            if (clip.name == name)
            {
                _selectedSFX = clip;
            }
        }
        if (_selectedSFX == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
           // Debug.Log("Playing " + _selectedSFX.name);
            _sfxSource.PlayOneShot(_selectedSFX.clip);
        }
    }


    public void AdjustBGMVol (float vol)
    {
        mixer.SetFloat("BGM", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("BGM", vol);
    }

    public void AdjustSFXVol(float vol)
    {
        mixer.SetFloat("SFX", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("SFX", vol);
    }

    public void ToggleSound()
    {
        if (_toggle)
        {
            //mixer.SetFloat("Master", 0);
            _musicSource.mute = true;
            _sfxSource.mute = true;
            _toggle = !_toggle;
        }
        else
        {
            //mixer.SetFloat("Master", 5);
            _musicSource.mute = false;
            _sfxSource.mute = false;
            _toggle = !_toggle;
        }

    }
}


