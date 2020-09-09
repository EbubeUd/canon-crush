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
    public class UIManager : MonoBehaviour
    {
        public Button PlayButton;
        public Button ExitButton;
        public Button SettingButton;
        public Button BackButton;

        public GameObject SettingsPanel;
        public GameObject MenuPanel;

        private void Start()
        {
            PlayButton.onClick.AddListener(delegate { Play(); });
            ExitButton.onClick.AddListener(delegate{ QuitGame(); });
            SettingButton.onClick.AddListener(delegate{ GotoSettings(); });
            BackButton.onClick.AddListener(delegate{ GotoMainMenu(); });
        }

        // Renders the sample screen
        public void Play()
        {
            SceneManager.LoadScene("SampleScene");
        }

        void QuitGame()
        {
            Application.Quit();
        }

        void GotoSettings()
        {
            SettingsPanel.SetActive(true);
            MenuPanel.SetActive(false);
        }

        void GotoMainMenu()
        {
            MenuPanel.SetActive(true);
            SettingsPanel.SetActive(false);
        }
    }
}
