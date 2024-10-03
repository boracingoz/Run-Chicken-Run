using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movements
{
    public class Jump
    {
        Rigidbody _rb;

        public Jump(PlayerController playerController)
        {
            _rb = playerController.gameObject.GetComponent<Rigidbody>();
            if (_rb == null)
            {
                _rb = playerController.gameObject.AddComponent<Rigidbody>();
            }
        }

        public void FixedTick(float jump)
        {
            if (_rb.velocity.y != 0)
            {
                return;
            }

            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z); // Y eksenindeki h�z s�f�rlan�yor
            _rb.AddForce(Vector3.up * jump, ForceMode.VelocityChange); // Kuvvet do�rudan jump ile �arp�l�yor
        }
    }
}
