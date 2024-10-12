using Abstracts.Utilities;
using Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : SingletonBehavior<GameManager>
    {
        public event Action OnGameStop;
        public event Action OnGameReset;

        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;
            OnGameStop?.Invoke();
        }

        public void LoadScene(string sceneName)
        {
            Time.timeScale = 1f;
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private System.Collections.IEnumerator LoadSceneAsync(string sceneName)
        {
            SoundManager.Instance.StopSound(1);
            Debug.Log($"Loading scene: {sceneName}");

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            if (asyncLoad.isDone)
            {
                SoundManager.Instance.PlaySound(2);
                Debug.Log($"Scene loaded: {sceneName}");
            }
            else
            {
                Debug.LogError($"Failed to load scene: {sceneName}");
            }
        }

        public void ResetGame()
        {
            OnGameReset?.Invoke();
        }


        public void ExitGame()
        {
            Debug.Log("oyundan çýkýlýyor!");
            Application.Quit();
        }

        private void OnDisable()
        {
            // Clean up events
            OnGameStop = null;
            OnGameReset = null;
        }
    }
}


