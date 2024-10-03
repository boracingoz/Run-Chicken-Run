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
        [SerializeField] float _jumpForce = 50f;
        [SerializeField] bool _isJump;

        HoriMover _horiMover;
        Jump _jump;

        private void Awake()
        {
            _horiMover = new HoriMover(this);
            _jump = new Jump(this);
        }

        private void FixedUpdate()
        {
            _horiMover.FixedTick(_horiDir, _moveSpeed);

            if (_isJump)
            {
                _jump.FixedTick(_jumpForce);
            }
            _isJump = false;
        }
    }
}


