using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _horiDir = 0f;
        [SerializeField] private float _moveSpeed = 10f;

        HoriMover _horiMover;

        private void Awake()
        {
            _horiMover = new HoriMover(this);
        }

        private void FixedUpdate()
        {
            _horiMover.FixedTick(_horiDir, _moveSpeed);
        }
    }
}


