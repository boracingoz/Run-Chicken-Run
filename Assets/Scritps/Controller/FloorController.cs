using System.Collections;
using UnityEngine;

namespace Controller
{
    public class FloorController : MonoBehaviour
    {
        Material _material;
        [Range(1,2.2f)]
        [SerializeField]private float _moveSpeed = 1;

        private void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
        }

        private void Update()
        {
            _material.mainTextureOffset += Vector2.down * Time.deltaTime * _moveSpeed;
        }
    }
}