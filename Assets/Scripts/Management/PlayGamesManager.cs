using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Management
{
    public class PlayGamesManager :  MonoBehaviour
    {
        public static PlayGamesPlatform platform;

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (platform == null)
                {
                    PlayGamesClientConfiguration playGamesClientConfiguration = new PlayGamesClientConfiguration.Builder().Build();
                    PlayGamesPlatform.DebugLogEnabled = true;
                    PlayGamesPlatform.InitializeInstance(playGamesClientConfiguration);
                    platform = PlayGamesPlatform.Activate();
                    SignIn();
                }
                else
                {
                    SignIn();
                }
            }
        }

        public static void SignIn()
        {
            //Publish event that signin has started 
            DelegateHandler.beginGooglePlayLoginDelegate?.Invoke();

            Social.localUser.Authenticate(success => {
                if (success)
                {
                    DelegateHandler.googlePlayLoginSuccessful?.Invoke();
                    Debug.Log($"Username: {Social.localUser.authenticated}");
                }
                else
                {
                    DelegateHandler.googlePlayLoginFailed?.Invoke();
                }

            });
        }

        public static void AddScoreToLeaderboard(string leaderboardId, long score)
        {
            Social.ReportScore(score, leaderboardId, success => { });
        }

        public static void ShowLeaderboardUI()
        {
            Social.ShowLeaderboardUI();
        }

    }
}
