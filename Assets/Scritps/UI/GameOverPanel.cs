using Manager;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {

        public void YesBTN()
        {
            GameManager.Instance.LoadScene("Game");
        }

        public void NoBTN()
        {
            GameManager.Instance.LoadScene("Menu");
        }
    }
}