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

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
            OnGameReset?.Invoke();  
        }

        public void ExitGame()
        {
            Debug.Log("oyundan çýkýlýyor!");
            Application.Quit();
        }

    }
}


