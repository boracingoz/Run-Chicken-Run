using System;
using System.Collections;
using System.Collections.Generic;
using Abstracts.Inputs;
using Inputs;
using Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;

        HoriMover _horizontalMover;
        Jump _jump;
        IInputListener _input;
        float _horizontal;
        bool _isJump;

        private void Awake()
        {
            _horizontalMover = new HoriMover(this);
            _jump = new Jump(this);
            _input = new InputListener(GetComponent<PlayerInput>());
        }

        void Update()
        {
            _horizontal = _input.Horizontal;

            if (_input.IsJump == true)
            {
                _isJump = true;

            }   
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontal, _moveSpeed);
            _horizontalMover.TickFixed(_horizontal, _moveSpeed);

            if (_isJump)
            {
                _jump.FixedTick(_jumpForce);
            }
            _isJump = false;
        }
    }
}
