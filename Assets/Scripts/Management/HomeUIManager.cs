using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Management
{
    public class HomeUIManager : MonoBehaviour
    {
        public Animator PlayButtonHolder;
        public Button PlayButton;
        public Button SettingButton;
        public Slider Loader;
        public GameObject MenuPanel;
        public Animator HowToPlayPanel;
        public Button HowToPlayButton;
        public Button HowToPlayCloseButton;
        public Animator OverlayAnimator;


        int progressLoaded = 0;
        bool gameStarted;



        private void Start()
        {
            PlayButtonHolder.SetBool("IsVisible", true);
            Loader.GetComponent<Animator>().SetBool("IsVisible", false);
            SettingButton.GetComponent<Animator>().SetBool("IsVisible", true);

            PlayButton.onClick.AddListener(delegate { Play(); });
            SettingButton.onClick.AddListener(delegate{ GotoSettings(); });
         
            progressLoaded = 0;
            gameStarted = false;

            HowToPlayButton.onClick.AddListener(delegate { ShowTutorial(); });
            HowToPlayCloseButton.onClick.AddListener(delegate { HideTutorial(); });

        }

        private void ShowTutorial()
        {
            OverlayAnimator.SetBool("IsVisible", true);
            HowToPlayPanel.SetBool("IsVisible", true);
        }

        private void HideTutorial()
        {
            OverlayAnimator.SetBool("IsVisible", false);
            HowToPlayPanel.SetBool("IsVisible", false);
        }


        private void GotoSettings()
        {
            SettingsManager.Instance.ShowSettingsModal();
        }


        // Renders the sample screen
        public void Play()
        {
            Loader.GetComponent<Animator>().SetBool("IsVisible", true);
            PlayButtonHolder.GetComponent<Animator>().SetBool("IsVisible", false);
            HowToPlayButton.GetComponent<Animator>().SetBool("IsVisible", false);
            SettingButton.GetComponent<Animator>().SetBool("IsVisible", false);
            InvokeRepeating("LoadProgress", 0.3f, 0.01f);
        }


      

        void LoadProgress()
        {
            if (gameStarted) return;
            progressLoaded ++;
            Loader.value = progressLoaded;
            if(progressLoaded >= 100)
            {
                gameStarted = true;
                CancelInvoke("LoadProgress");
                GameManager.Instance.GoToScene(SceneIds.GameScene);
            }
        }


    }
}
