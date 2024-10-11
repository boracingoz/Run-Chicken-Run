using UnityEngine;
using Enums;
using Manager;
using Controller;
using System.Collections.Generic;

namespace Controller
{
    public class SpawnerController : MonoBehaviour
    {
        [Range(1f, 5f)][SerializeField] float _minSpawnInterval = 1f;
        [Range(2f, 10f)][SerializeField] float _maxSpawnInterval = 3f;
        [SerializeField] Transform[] _spawnPoints;

        private float _nextSpawnTime;
        private int _index = 0;
        private float _maxAddEnemyTime;
        private List<int> _availableSpawnPoints;

        public bool CanIncrease => _index < EnemyManager.Instance.Count;

        private void Start()
        {
            if (_spawnPoints.Length == 0)
            {
                Debug.LogError("No spawn points assigned to SpawnerController!");
            }
            _availableSpawnPoints = new List<int>();
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                _availableSpawnPoints.Add(i);
            }
            SetNextSpawnTime();
        }

        private void Update()
        {
            if (Time.time >= _nextSpawnTime)
            {
                Spawn();
                SetNextSpawnTime();
            }

            if (!CanIncrease) return;

            if (Time.time >= _maxAddEnemyTime)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
            }
        }

        private void Spawn()
        {
            if (_spawnPoints.Length == 0 || _availableSpawnPoints.Count == 0) return;

            EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0, _index));

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

        private void SetNextSpawnTime()
        {
            _nextSpawnTime = Time.time + Random.Range(_minSpawnInterval, _maxSpawnInterval);
        }

        private void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }
    }
}