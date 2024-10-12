using Abstracts.Utilities;
using Controller;
using Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class EnemyManager : SingletonBehavior<EnemyManager>
    {
        [SerializeField] private float _addDelayTime = 50f;
        [SerializeField] private EnemyController[] _enemyPrefabs;

        private readonly Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();


        public float AddDelayTime => _addDelayTime;
        public int EnemyTypeCount => _enemyPrefabs.Length;

        private void Awake()
        {
            SingletonThisObject(this);
        }

        private void Start()
        {
            InitializePool();
        }



        private void InitializePool()
        {
            if (_enemyPrefabs.Length != Enum.GetValues(typeof(EnemyEnum)).Length)
            {
                Debug.LogError("Enum ile prefab uyuþmuyor...");
                return;
            }

            foreach (var prefab in _enemyPrefabs)
            {
                var enemyQueue = new Queue<EnemyController>();

                for (int j = 0; j < 10; j++)
                {
                    var newEnemy = Instantiate(prefab);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.SetParent(transform);
                    enemyQueue.Enqueue(newEnemy);
                }
                _enemies.Add(prefab.EnemyType, enemyQueue);
            }
        }

        public void ReturnToPool(EnemyController enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.transform.SetParent(transform);
            _enemies[enemy.EnemyType].Enqueue(enemy);
        }


        public EnemyController GetFromPool(EnemyEnum enemyType)
        {
            var enemyQueue = _enemies[enemyType];
            if (enemyQueue.Count == 0)
            {
                var newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                newEnemy.gameObject.SetActive(false);
                enemyQueue.Enqueue(newEnemy);
            }
            return enemyQueue.Dequeue();
        }

        public int GetEnemyCount()
        {
            return _enemyPrefabs.Length; 
        }


        public EnemyController GetPool(EnemyEnum enemyType)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyType];

            if (enemyControllers.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                    newEnemy.gameObject.SetActive(false);
                    enemyControllers.Enqueue(newEnemy);
                }
            }

            EnemyController enemy = enemyControllers.Dequeue();
            enemy.gameObject.SetActive(true);

            return enemy;
        }

    }
}

