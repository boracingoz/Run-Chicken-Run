using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] GameObject _enemyPrefab;
        [Range(01f, 5f)][SerializeField] float _min = 0.1f;
        [Range(6f, 10f)][SerializeField] float _max = 10f;


        float _maxSpawnTime;
        float _currentSpawnTime = 0f;

        private void OnEnable()
        {
            RandomSpawnTime();
        }

        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;    
            if (_currentSpawnTime > _maxSpawnTime)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            Instantiate(_enemyPrefab, transform.position, transform.rotation);

            _currentSpawnTime = 0f;
            RandomSpawnTime();
        }

        void RandomSpawnTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }

    }

}
