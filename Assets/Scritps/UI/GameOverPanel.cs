using Manager;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {

        public void YesBTN()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadScene("Game");
            }
            else
            {
                Debug.LogError("GameManager instance is null!");
            }
        }

        public void NoBTN()
        {
            GameManager.Instance.LoadScene("Menu");
        }
    }
}