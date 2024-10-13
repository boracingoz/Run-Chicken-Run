using System;
using System.Collections;
using System.Collections.Generic;
using Abstracts.Inputs;
using Controller;
using Inputs;
using Manager;
using Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] private Vector3 _startPosition;

        HoriMover _horizontalMover;
        Jump _jump;
        IInputListener _input;
        float _horizontal;
        bool _isJump;
        bool _isDead= false;

        private void Awake()
        {
            _startPosition = transform.position;
            _horizontalMover = new HoriMover(this);
            _jump = new Jump(this);
            _input = new InputListener(GetComponent<PlayerInput>());
        }


        void Update()
        {
            if (_isDead || Time.timeScale == 0) 
            {
                return;
            }

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

            if (_isDead || Time.timeScale == 0) 
            {
                return;
            }

            _horizontalMover.TickFixed(_horizontal, _moveSpeed);

            if (_isJump)
            {
                _jump.FixedTick(_jumpForce);
            }
            _isJump = false;
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameReset += ResetPlayerPosition;
        }


        private void OnTriggerEnter(Collider other)
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                _isDead = true;
                GameManager.Instance.StopGame(); 
               
            }
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameReset -= ResetPlayerPosition;
        }

        private void ResetPlayerPosition()
        {
            transform.position = _startPosition;  
            
        }

    }
}
