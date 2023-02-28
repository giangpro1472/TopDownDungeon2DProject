using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public static AudioController instance;

    public Slider musicSlider, sfxSlider;

    private void Awake()
    {
        if (AudioController.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += LoadMusic;
        PlayMusic("Menu");
    }

    public void SaveMusic()
    {
        float currentMusicSound = musicSource.volume;
        float currentSFXSound = sfxSource.volume;
       
        PlayerPrefs.SetFloat("Music", currentMusicSound);
        PlayerPrefs.SetFloat("SFX", currentSFXSound);

    }    

    public void LoadMusic(Scene s, LoadSceneMode mode)
    {
        if (PlayerPrefs.GetFloat("Music") <= 0 && PlayerPrefs.GetFloat("SFX") <= 0)
        {
            Debug.Log("Load State Music");
            musicSource.volume = 1;
            sfxSource.volume = 1;
            musicSlider.value = musicSource.volume;
            sfxSlider.value = sfxSource.volume;
            return;
        }
        musicSource.volume = PlayerPrefs.GetFloat("Music");
        musicSlider.value = musicSource.volume;


        sfxSource.volume = PlayerPrefs.GetFloat("SFX");
        sfxSlider.value = sfxSource.volume;
    }
    
    public void PlayMusic(string name)
    {
        musicSource.Stop();
        Sound s = Array.Find(musicSounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        musicSource.clip = s.clip;
        musicSource.Play();
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        sfxSource.clip = s.clip;
        sfxSource.PlayOneShot(s.clip);
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        sfxSource.mute = !musicSource.mute;
    }

    public void MusicVolume(bool right)
    {
        if (right)
        {
            musicSource.volume += 0.1f;
            if (musicSource.volume >= 1)
            {
                musicSource.volume = 1;
            }
            musicSlider.value = musicSource.volume;
            //Debug.Log("Music: " + musicSource.volume);
        }
        else
        {
            musicSource.volume -= 0.1f;
            if (musicSource.volume <= 0)
            {
                musicSource.volume = 0;
            }
            musicSlider.value = musicSource.volume;
            //Debug.Log("Music: " + musicSource.volume);
        }
    }

    public void SFXVolume(bool right)
    {
        if (right)
        {
            sfxSource.volume += 0.1f;
            if (sfxSource.volume >= 1)
            {
                sfxSource.volume = 1;
            }
            sfxSlider.value = sfxSource.volume;
            //Debug.Log("sfx: " + sfxSource.volume);
        }
        else
        {
            sfxSource.volume -= 0.1f;
            if (sfxSource.volume <= 0)
            {
                sfxSource.volume = 0;
            }
            sfxSlider.value = sfxSource.volume;
            //Debug.Log("sfx: " + sfxSource.volume);
        }

    }
}
