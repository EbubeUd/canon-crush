using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity;

namespace Assets.Scripts.Management
{
    class ScoreManager : MonoBehaviour
    {
        public ScoreManager Instance;
        public LevelRequirementModel levelRequirements;

        public int Score;
        public int TargetScore;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        void AddScore(int value)
        {
            Score = Score + value;
        }

        bool GetObjectiveStatus()
        {
            if (Score >= TargetScore)
            {
                return true;
            }

            return false;
        }

        void SetLevelRequirements(LevelRequirementModel _levelRequirements)
        {
            levelRequirements = _levelRequirements;
        }

        public void SaveScore()
        {
            var currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
            if (currentHighScore > Score)
                return;
            else
                PlayerPrefs.GetInt("HighScore", Score);

            DelegateHandler.HighScoreReached(Score);
        }
    }
}
