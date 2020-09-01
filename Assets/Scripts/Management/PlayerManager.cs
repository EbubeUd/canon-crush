using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Management
{
    public class PlayerManager : MonoBehaviour
    {
        public string Name;
        public Animator NameInputPanel;
        public Button SetNameButton;
        public InputField NameInput;

        private void Start()
        {
            SetNameButton.onClick.AddListener(delegate { SetName(); });
        }

        public void SetName(string name)
        {
            Name = name;
            PlayerPrefs.SetString("PlayerName", name);
        }

        public string GetName()
        {
            Name = PlayerPrefs.GetString("PlayerName", "Player");
            return Name;
        }

        public void DisplayNameInput()
        {
            NameInputPanel.SetBool("IsVisible", true);
        }

        public void SetName()
        {
            Name = NameInput.text;
            PlayerPrefs.SetString("PlayerName", Name);
        }

        public void ShowInputForm()
        {
            NameInputPanel.SetBool("IsVisible", true);
        }

        public void HideInputForm()
        {
            NameInputPanel.SetBool("IsVisible", false);
        }
    }
}
