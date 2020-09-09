using System.Collections;
using UnityEngine.Audio; 
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enums;
using Assets.Scripts.Management;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip BoxDestructionClip;
    public AudioClip BoxSpawnClip;
    public AudioClip FireClip;
    public AudioClip BoosterClip;
    public AudioSource MusicAudioSource;
    public List<AudioSource> AudioSources =  new List<AudioSource>();

    
    private void Awake()
    {
        if (Instance == null)  Instance = this;
    }


    private void Start()
    {
        DelegateHandler.BoxDestroyed += BoxDestroyed;
        DelegateHandler.BoxSpawned += BoxSpawned;
        DelegateHandler.GunFired += GunFired;
        DelegateHandler.GamePaused += OnGamePaused;

        MusicAudioSource.Play();
    }
    

    public void UpdateVolumes(float musicVolume, float SFXVolume)
    {
        MusicAudioSource.volume = musicVolume;

        for (int i = 0; i < AudioSources.Count; i++)
        {
            AudioSources[i].volume = SFXVolume;
        }
    }


    void BoxDestroyed(ColumnType columnType, BoxType boxType)
    {
        if (boxType == BoxType.AntiRacistAid)
        {
            BoosterDestroyed();
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
    

    private void OnDestroy()
    {
        DelegateHandler.BoxDestroyed -= BoxDestroyed;
        DelegateHandler.BoxSpawned -= BoxSpawned;
        DelegateHandler.GunFired -= GunFired;
        DelegateHandler.GamePaused -= OnGamePaused;
    }
}
