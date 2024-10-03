using System.Collections;
using System.Collections.Generic;
using Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Inputs
{
    public class InputListener : IInputListener
    {
        PlayerInput _playerInput;

        public float Horizontal { get; private set; }
        public bool IsJump { get; private set; }

        public InputListener(PlayerInput playerInput)
        {
            _playerInput = playerInput;

            _playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;
            _playerInput.currentActionMap.actions[1].performed += OnJump;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            IsJump = context.ReadValueAsButton();
        }

        void OnHorizontalMove(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<float>();
        }
    }
}