using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Movements
{
    public class HoriMover
    {
        PlayerController _playerController;
        private const float MIN_X = -3.05f;
        private const float MAX_X = 3.05f;

        public HoriMover(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void TickFixed(float horizontal, float moveSpeed)
        {
            if (horizontal == 0f) return;

            Vector3 movement = Vector3.right * horizontal * Time.deltaTime * moveSpeed;
            Vector3 newPosition = _playerController.transform.position + movement;

            // X pozisyonunu sýnýrlar içinde tutuyoruz
            newPosition.x = Mathf.Clamp(newPosition.x, MIN_X, MAX_X);

            _playerController.transform.position = newPosition;
        }
    }
}