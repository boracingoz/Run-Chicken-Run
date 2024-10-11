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
        [SerializeField] float _initialMoveSpeed = 5f;
        [SerializeField] float _maxMoveSpeed = 15f;
        [SerializeField] float _accelerationRate = 0.1f;
        [SerializeField] float _lifeTime = 10f;
        [SerializeField] EnemyEnum _enemyEnum;

        private float _currentMoveSpeed;
        private float _currentLifeTime = 0f;
        private EnemyMovement _enemyMovement;
        private static float _gameStartTime;

        public float MoveSpeed => _currentMoveSpeed;
        public EnemyEnum EnemyType => _enemyEnum;

        private void Awake()
        {
            _enemyMovement = new EnemyMovement(this);
        }

        private void OnEnable()
        {
            if (_gameStartTime == 0)
            {
                _gameStartTime = Time.time;
            }
            _currentMoveSpeed = _initialMoveSpeed;
            _currentLifeTime = 0f;
        }


        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime > _lifeTime)
            {
                _currentLifeTime = 0f;
                KillYourself();
            }

            if (Time.time - _gameStartTime > 20f)
            {
                AccelerateEnemy();
            }
        }

        private void FixedUpdate()
        {
            _enemyMovement.FixedTick();
        }

        public static void ResetStatics()
        {
            _gameStartTime = 0;
        }


        private void KillYourself()
        {
            EnemyManager.Instance.SetPool(this);
        }

        private void AccelerateEnemy()
        {
            _currentMoveSpeed = Mathf.Min(_currentMoveSpeed + _accelerationRate * Time.deltaTime, _maxMoveSpeed);
        }
    }
}