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
        public Slider sfxSlider;
        public Animator SettingsPanel;
        public Button CloseButton;
        public Animator OverlayPanel;
        public Button ExitButton;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        [HideInInspector]
        public float SFXVolume;
        [HideInInspector]
        public float MusicVolume;

        private void Start()
        {
            SFXVolume = PlayerPrefs.GetInt("SFXVolume", 1);
            MusicVolume = PlayerPrefs.GetInt("MusicVolume", 1);
            musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
            sfxSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
            CloseButton.onClick.AddListener(delegate { HideSettingsModal(); });
            ExitButton.onClick.AddListener(delegate { Exit(); });
            musicSlider.value = MusicVolume;
            sfxSlider.value = SFXVolume;
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

        void SetMusicVolume()
        {
           SetMusic(musicSlider.value);
        }

        void SetSFXVolume()
        {
           SetSFX(sfxSlider.value);
        }

        public void SetSFX(float volume)
        {
            SFXVolume = volume;
            PlayerPrefs.SetFloat("SFXVolume", volume);
        }


        public void SetMusic(float volume)
        {
            MusicVolume = volume;
            PlayerPrefs.SetFloat("MusicVolume", volume);
        }

        public float GetSFXVolume()
        {
            return PlayerPrefs.GetFloat("SFXVolume", 1);
        }

        public float GetMusicVolume()
        {
            return PlayerPrefs.GetFloat("MusicVolume", 1);
        }

        public void ShowSettingsModal()
        {
            OverlayPanel.SetBool("IsVisible", true);
            SettingsPanel.SetBool("IsVisible", true);
        }


        public void HideSettingsModal()
        {
            if (GameManager.Instance.IsGamePaused) GameManager.Instance.PauseGame(false);
            OverlayPanel.SetBool("IsVisible", false);
            SettingsPanel.SetBool("IsVisible", false);
        }
    }
}
