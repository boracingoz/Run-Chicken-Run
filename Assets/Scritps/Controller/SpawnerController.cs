using UnityEngine;
using Enums;
using Manager;
using Controller;
using System.Collections.Generic;
using System.Reflection;

namespace Controller
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private float _minSpawnInterval = 1f;
        [SerializeField] private float _maxSpawnInterval = 3f;
        [SerializeField] private Transform[] _spawnPoints;

        private float _nextSpawnTime;
        private int _enemyIndex = 0;
        private float _maxAddEnemyTime;
        private List<int> _availableSpawnPoints;

        public bool CanIncrease => _enemyIndex < EnemyManager.Instance.EnemyTypeCount;

        private void Start()
        {
            InitializeSpawnPoints();
            SetNextSpawnTime();
        }


        private void Update()
        {
            if (Time.time >= _nextSpawnTime)
            {
                SpawnEnemy();
                SetNextSpawnTime();
            }

            if (CanIncrease && Time.time >= _maxAddEnemyTime)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                _enemyIndex++;
            }
        }

        private void InitializeSpawnPoints()
        {
            if (_spawnPoints.Length == 0)
            {
                Debug.LogError("Spawn assign edilemedi");
                return;
            }

            _availableSpawnPoints = new List<int>();
            for (int i = 0; i < _spawnPoints.Length; i++)
                _availableSpawnPoints.Add(i);
        }

        private void SpawnEnemy()
        {
            if (_availableSpawnPoints.Count == 0) return;

            var enemy = EnemyManager.Instance.GetFromPool((EnemyEnum)Random.Range(0, _enemyIndex));
            int spawnIndex = _availableSpawnPoints[Random.Range(0, _availableSpawnPoints.Count)];
            Transform spawnPoint = _spawnPoints[spawnIndex];

            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;

            if (!enemy.gameObject.activeSelf)
            {
                enemy.gameObject.SetActive(true);
            }

            _availableSpawnPoints.Remove(spawnIndex);
            if (_availableSpawnPoints.Count == 0) InitializeSpawnPoints();
        }

        private void SetNextSpawnTime()
        {
            _nextSpawnTime = Time.time + Random.Range(_minSpawnInterval, _maxSpawnInterval);
        }



        private void Spawn()
        {
            if (_spawnPoints.Length == 0 || _availableSpawnPoints.Count == 0) return;

            EnemyController newEnemy = EnemyManager.Instance.GetPool(
                (EnemyEnum)Random.Range(0, EnemyManager.Instance.GetEnemyCount())
            );

            int spawnPointIndex = _availableSpawnPoints[Random.Range(0, _availableSpawnPoints.Count)];
            Transform spawnPoint = _spawnPoints[spawnPointIndex];

            newEnemy.transform.position = spawnPoint.position;
            newEnemy.transform.rotation = spawnPoint.rotation;

            newEnemy.gameObject.SetActive(true);

            _availableSpawnPoints.Remove(spawnPointIndex);

            if (_availableSpawnPoints.Count == 0)
            {
                for (int i = 0; i < _spawnPoints.Length; i++)
                {
                    _availableSpawnPoints.Add(i);
                }
            }
        }


    }
}