using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public Slider musicSlider, sfxSlider;
    bool muteMusic, muteSfx;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex.Equals(0))
        {
            PlayMusic("Main BG");
        }
        
    }

    public void PlayMusic(string name) 
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name) 
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ChangeVolumeSFX(bool mute){
        if(mute){
            muteSfx = !muteSfx;
        }
        if(muteSfx){
            sfxSource.volume = 0;
            sfxSlider.gameObject.SetActive(false);
        }else{
            sfxSlider.gameObject.SetActive(true);
            sfxSource.volume = sfxSlider.value;
        }
    }

    public void ChangeVolumeMusic(bool mute){
        if(mute){
            muteMusic = !muteMusic;
        }
        if(muteMusic){
            musicSource.volume = 0;
            musicSlider.gameObject.SetActive(false);
        }else{
            musicSlider.gameObject.SetActive(true);
            musicSource.volume = musicSlider.value;
        }
    }
   
}
