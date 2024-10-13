using Manager;
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
        }

        public void NoBTN()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadScene("Menu");  
            }
        }
    }
}
