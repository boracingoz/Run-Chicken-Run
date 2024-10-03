using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
namespace Movements
{
    public class Jump
    {
        Rigidbody _rb;
        public bool CanJump => _rb.velocity.y != 0;

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
            if (CanJump)
            {
                return;
            }
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z); //çalışmazsa buraya dön 
            _rb.AddForce(Vector3.up * jump, ForceMode.VelocityChange); // Kuvvet doðrudan jump ile çarpýlýyo
        }


        //private Rigidbody _rb;
        //public Jump(PlayerController playerController)
        //{
        //    _rb = playerController.GetComponent<Rigidbody>();
        //}
        //public void FixedTick(float jump)
        //{
        //    if (_rb.velocity.y != 0) return;
        //    Debug.Log(_rb.velocity.y);

        //    _rb.velocity = Vector3.zero;
        //    _rb.AddForce(Vector3.up * Time.deltaTime * jumpForce);
        //}
    }
}