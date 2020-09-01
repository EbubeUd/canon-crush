using System.Collections;
using UnityEngine.Audio; 
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enums;
using Assets.Scripts.Management;

public class AudioManager : MonoBehaviour
{

    public AudioClip BoxDestructionClip;
    public AudioClip BoxSpawnClip;
    public AudioClip FireClip;
    public AudioClip BoosterClip;


    public List<AudioSource> AudioSources =  new List<AudioSource>();
    public AudioSource MusicAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        DelegateHandler.BoxDestroyed += BoxDestroyed;
        DelegateHandler.BoxSpawned += BoxSpawned;
        DelegateHandler.GunFired += GunFired;
        DelegateHandler.GamePaused += OnGamePaused;

        UpdateVolumes();
        MusicAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVolumes();
    }

    public void UpdateVolumes()
    {
        MusicAudioSource.volume = SettingsManager.Instance.GetMusicVolume();
        for (int i = 0; i < AudioSources.Count; i++)
        {
            AudioSources[i].volume = SettingsManager.Instance.GetSFXVolume();
        }
    }

    void BoxDestroyed(ColumnType columnType, BoxType boxType)
    {
        if (boxType == BoxType.AntiRacistAid)
        {
            BoosterDestroyed();
            return;
        }
        else
        {
            AudioSource audioSource = AudioSources.FirstOrDefault(x => x.isPlaying == false);
            if (audioSource)
            {
                audioSource.clip = BoxDestructionClip;
                audioSource.Play();
            }
        }

    }


    void BoosterDestroyed()
    {
        AudioSource audioSource = AudioSources.FirstOrDefault(x => x.isPlaying == false);
        if (audioSource)
        {
            audioSource.clip = BoosterClip;
            audioSource.Play();
        }
    }

    void GunFired()
    {
        AudioSource audioSource = AudioSources.FirstOrDefault(x => x.isPlaying == false);
        if (audioSource)
        {
            audioSource.clip = FireClip;
            audioSource.Play();
        }
    }

    void BoxSpawned()
    {
        AudioSource audioSource = AudioSources.FirstOrDefault(x => x.isPlaying == false);
        if (audioSource)
        {
            audioSource.clip = BoxSpawnClip;
            audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        DelegateHandler.BoxDestroyed -= BoxDestroyed;
        DelegateHandler.BoxSpawned -= BoxSpawned;
        DelegateHandler.GunFired -= GunFired;
        DelegateHandler.GamePaused -= OnGamePaused;
    }

    void OnGamePaused(bool status)
    {
        if (status)
        {
            for (int i = 0; i < AudioSources.Count; i++) AudioSources[i].Pause();
            MusicAudioSource.Pause();
        }
        else
        {
            for (int i = 0; i < AudioSources.Count; i++) AudioSources[i].Play();
            MusicAudioSource.Play();
        }


    }


}
