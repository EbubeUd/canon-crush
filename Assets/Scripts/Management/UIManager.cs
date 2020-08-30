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

        private void Start()
        {
            PlayButton.onClick.AddListener(delegate { Play(); });
        }

        // Renders the sample screen
        public void Play()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
