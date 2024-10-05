using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class MenuUI : MonoBehaviour
    {


        public void StartBTN()
        {
            GameManager.Instance.LoadScene();
        }

        public void ExitBTN()
        {
            GameManager.Instance.ExitGame();
        }
    }

}

