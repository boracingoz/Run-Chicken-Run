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
        [SerializeField] private float _initialMoveSpeed = 5f;
        [SerializeField] private float _maxMoveSpeed = 15f;
        [SerializeField] private float _accelerationRate = 0.1f;
        [SerializeField] private float _lifeTime = 10f;
        [SerializeField] private EnemyEnum _enemyEnum;

        public float _currentMoveSpeed;
        private float _currentLifeTime;
        private EnemyMovement _enemyMovement;

        public EnemyEnum EnemyType => _enemyEnum;

        private void Awake()
        {
            _enemyMovement = new EnemyMovement(this);
        }

        private void OnEnable()
        {
            _currentMoveSpeed = _initialMoveSpeed;
            _currentLifeTime = 0f;
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime >= _lifeTime)
            {
                KillYourself();
            }

            if (Time.time > 20f)
                Accelerate();
        }

        private void FixedUpdate()
        {
            _enemyMovement.FixedTick();
        }

        private void KillYourself()
        {
            EnemyManager.Instance.ReturnToPool(this);
        }

        private void Accelerate()
        {
            _currentMoveSpeed = Mathf.Min(_currentMoveSpeed + _accelerationRate * Time.deltaTime, _maxMoveSpeed);
        }

    }
}