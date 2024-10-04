using Movements;
using System.Collections;
using UnityEngine;

namespace Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed;
        EnemyMovement _enemyMovement;

        public float MoveSpeed => _moveSpeed;

        private void Awake()
        {
            _enemyMovement = new EnemyMovement(this);
        }

        private void FixedUpdate()
        {
            _enemyMovement.FixedTick();
        }

    }
}