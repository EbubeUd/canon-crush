using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Management
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Instance;
        public Slider musicSlider;
        public Slider SFXSlider;
        public Animator SettingsPanel;
        public Button CloseButton;
        public Animator OverlayPanel;
        public Button ExitButton;
        //[HideInInspector]
        public float SFXVolume;
        //[HideInInspector]
        public float MusicVolume;


        private void Awake()
        {
            if (Instance == null) Instance = this;
        }


        private void Start()
        {
            MusicVolume = GetMusicVolume();
            SFXVolume = GetSFXVolume();

            musicSlider.value = MusicVolume;
            SFXSlider.value = SFXVolume;

            musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
            SFXSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });

            CloseButton.onClick.AddListener(delegate { HideSettingsModal(); });
            ExitButton.onClick.AddListener(delegate { Exit(); });
            
            AudioManager.Instance.UpdateVolumes(MusicVolume, SFXVolume);
        }


        private float GetMusicVolume()
        {
            return PlayerPrefs.GetFloat("MusicVolume", 1);
        }

        
        private float GetSFXVolume()
        {
            return PlayerPrefs.GetFloat("SFXVolume", 1);
        }


        private void SetMusicVolume()
        {
            MusicVolume = musicSlider.value;
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
            AudioManager.Instance.UpdateVolumes(MusicVolume, SFXVolume);
        }


        private void SetSFXVolume()
        {
            SFXVolume = SFXSlider.value;
            PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
            AudioManager.Instance.UpdateVolumes(MusicVolume, SFXVolume);
        }


        public void ShowSettingsModal()
        {
            OverlayPanel.SetBool("IsVisible", true);
            SettingsPanel.SetBool("IsVisible", true);
        }


        public void HideSettingsModal()
        {
            OverlayPanel.SetBool("IsVisible", false);
            SettingsPanel.SetBool("IsVisible", false);

            if (GameManager.Instance.IsGamePaused) GameManager.Instance.PauseGame(false);
        }
        

        private void Exit()
        {
            if(GameManager.Instance.GetCurrentScene() == SceneIds.HomeScene)
            {
                Application.Quit();
            }
            else
            {
                GameManager.Instance.GoToScene(SceneIds.HomeScene);
            }
        }


        private void OnDestroy()
        {
            PlayerPrefs.Save();
        }
    }
}