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
        [SerializeField] float _addDelayTime = 50f;
        [SerializeField] EnemyController[] _enemyPrefabs;

        Dictionary<EnemyEnum, Queue<EnemyController>>  _enemies = new Dictionary < EnemyEnum, Queue<EnemyController>>();

        public float AddDelayTime => _addDelayTime;

        public int Count => _enemyPrefabs.Length;

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
                Debug.LogError("EnemyPrefabs'lerin içerisinde dizi hatasý var!.");
                return;
            }

            for (int i = 0; i < _enemyPrefabs.Length; i++)
            {
                Queue<EnemyController> enemyController = new Queue<EnemyController>();
                for (int j = 0; j < 10; j++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[i]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyController.Enqueue(newEnemy);
                }

                _enemies.Add((EnemyEnum)i, enemyController);
            }
        }


        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false); 
            enemyController.transform.parent = this.transform;

            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);
        }

        public EnemyController GetPool(EnemyEnum enemyType)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyType];

            if (enemyControllers.Count == 0)
            {
                for (int  i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                    enemyControllers.Enqueue(newEnemy);
                }
            }

            return enemyControllers.Dequeue();
        }
    }
}

