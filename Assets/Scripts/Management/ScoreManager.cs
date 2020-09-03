using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity;
using UnityEngine.UI;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Management
{
    class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        public Text ScoreText;
        public Text BestScoreText;
        public Text MatchesText;
        public Text ComboText;
        public Text CurrentScoreText;
        public Animator Overlay;
        public Animator ScorePanel;

        public Button RetryButton;
        public Button MenuButton;
        

        [HideInInspector]
        public int Score;

        int Matches;
        int Combos;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        

        private void Start()
        {
            ScoreText.text = "Score: 0";
            Score = 0;
            DelegateHandler.MatchAttained += OnMatchAttained;
            DelegateHandler.BoxDestroyed += OnBoxDestroyed;
            DelegateHandler.ComboAchieved += OnComboAchieved;


            MenuButton.onClick.AddListener(delegate { HideScorePanel(); Invoke("Menu", 0.5f); });
            RetryButton.onClick.AddListener(delegate { HideScorePanel(); Invoke("Retry", 0.5f); });

        }

        void AddScore(int value)
        {
            Score = Score + value;
            ScoreText.text = Score.ToString();
        }

        void OnBoxDestroyed(ColumnType columnType, BoxType boxType)
        {
            AddScore(50);
        }

        void OnMatchAttained()
        {
            Matches++;
            MatchesText.text = $"Matches: {Matches.ToString()}";
            AddScore(200);
        }

        void OnComboAchieved()
        {
            Combos++;
            ComboText.text = $"Combos: {Combos.ToString()}";
            AddScore(500);
        }

        public void SaveScore()
        {
            var currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
            if (currentHighScore < Score)
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }

            ShowScorePanel();

        }

        void ShowScorePanel()
        {
            BestScoreText.text = $"Best Score: {PlayerPrefs.GetInt("HighScore").ToString()}";
            CurrentScoreText.text = Score.ToString();
            Overlay.SetBool("IsVisible", true);
            ScorePanel.SetBool("IsVisible", true);
        }

        void HideScorePanel()
        {
            Overlay.SetBool("IsVisible", false);
            ScorePanel.SetBool("IsVisible", false);
        }

        void Retry()
        {
            GameManager.Instance.GoToScene(SceneIds.GameScene);
        }

        void Menu()
        {
            GameManager.Instance.GoToScene(SceneIds.HomeScene);
        }

        private void OnDisable()
        {
            DelegateHandler.MatchAttained -= OnMatchAttained;
            DelegateHandler.BoxDestroyed -= OnBoxDestroyed;
            DelegateHandler.ComboAchieved -= OnComboAchieved;
        }



    }
}
