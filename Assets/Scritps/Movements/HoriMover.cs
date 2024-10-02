using Controller;
using System.Collections;
using System.Collections.Generic;
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

        public void FixedTick(float horizontal, float moveSpeed)
        {
            if (horizontal == 0f)
            {
                return;
            }

            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moveSpeed);
        }
    }
}


