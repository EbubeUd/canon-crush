using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Management
{
    public class GameUIManager : MonoBehaviour
    {
        public Button PauseButton;
        

        private void Start()
        {
            PauseButton.onClick.AddListener(delegate { PauseGame(); });
            PauseButton.interactable = false;
            Invoke("EnableButtons", 5);
        }

        private void EnableButtons()
        {
            PauseButton.interactable = true;
        }

        private void PauseGame()
        {
            GameManager.Instance.PauseGame(true);
            SettingsManager.Instance.ShowSettingsModal();
        }
    }
}
