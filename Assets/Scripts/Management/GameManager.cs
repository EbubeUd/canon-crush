using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Management
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public SceneIds CurrentScene;
        [HideInInspector]
        public bool IsGamePaused;
        public System.Random Rand;


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Rand = new System.Random();
            }
        }


        public void PauseGame(bool status)
        {
            IsGamePaused = status;
            DelegateHandler.GamePaused(status);
        }


        internal SceneIds GetCurrentScene()
        {
            return CurrentScene;
        }


        internal void GoToScene(SceneIds sceneId)
        {
            CurrentScene = sceneId;
            switch (sceneId)
            {
                case SceneIds.HomeScene:
                    SceneManager.LoadScene("HomeScene");
                    break;
                case SceneIds.GameScene:
                    SceneManager.LoadScene("SampleScene");
                    break;
            }

            if (IsGamePaused) PauseGame(false);
        }
    }
}