using Enums;
using Manager;
using Movements;
using System;
using System.Collections;
using UnityEngine;

namespace Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _lifeTime = 1f;
        [SerializeField] EnemyEnum _enemyEnum;


        public float MoveSpeed => _moveSpeed;

        EnemyMovement _enemyMovement;
        float _currentLifeTime = 0f;

        public EnemyEnum EnemyType => _enemyEnum;

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
            EnemyManager.Instance.SetPool(this);
        }

    }
}