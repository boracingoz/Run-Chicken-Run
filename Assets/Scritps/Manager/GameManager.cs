using Abstracts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameManager : SingletonBehavior<GameManager>
    {
        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;
        }

        public void LoadScene()
        {
            Debug.Log("Oyun baþlýyor...");
        }

        public void ExitGame()
        {
            Debug.Log("oyundan çýkýlýyor!");
            Application.Quit();
        }
    }
}


