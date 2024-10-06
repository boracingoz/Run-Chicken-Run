using Manager;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameOverPanel _gameOverPanel;


        private void Awake()
        {
            _gameOverPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameStop += HandleOnGameStop;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameStop -= HandleOnGameStop;
        }

        private void HandleOnGameStop()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }
    }
}