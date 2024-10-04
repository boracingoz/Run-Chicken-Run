using Movements;
using System;
using System.Collections;
using UnityEngine;

namespace Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        EnemyMovement _enemyMovement;
        [SerializeField] float _lifeTime = 1f;

        public float MoveSpeed => _moveSpeed;
        float _currentLifeTime = 0f;

        private void Awake()
        {
            _enemyMovement = new EnemyMovement(this);
        }

        private void LateUpdate()
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime > _lifeTime)
            {
                _currentLifeTime = 0f;
                KillYourSelef();
            }
        }


        private void FixedUpdate()
        {
            _enemyMovement.FixedTick();
        }
        private void KillYourSelef()
        {
            Destroy(gameObject);
        }

    }
}