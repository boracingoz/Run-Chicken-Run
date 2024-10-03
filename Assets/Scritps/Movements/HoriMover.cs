using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
namespace Movements
{
    public class HoriMover
    {
        PlayerController _playerController;
        public HoriMover(PlayerController playerController)
        {
            _playerController = playerController;
        }
        public void TickFixed(float horizontal, float moveSpeed)
        {
            if (horizontal == 0f) return;

            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moveSpeed);
        }
    }
}

#region Yedek Mover
//using System.Collections;
//using System.Collections.Generic;
//using Controllers;
//using UnityEngine;

//namespace Movements
//{
//    public class HorizontalMover
//    {
//        PlayerController _playerController;
//        public HorizontalMover(PlayerController playerController)
//        {
//            _playerController = playerController;
//        }
//        public void TickFixed(float horizontal, float moveSpeed)
//        {
//            if (horizontal == 0f) return;

//            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moveSpeed);
//        }
//    }
//}
#endregion