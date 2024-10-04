using Controller;
using System.Collections;
using UnityEngine;

namespace Movements
{
    public class EnemyMovement
    {
        EnemyController _enemyController;
        private float _moveSpeed;

        public EnemyMovement(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _moveSpeed = _enemyController.MoveSpeed;    
        }

        public void FixedTick(float veritcal = 1)
        {
            _enemyController.transform.Translate(Vector3.back * veritcal * _moveSpeed * Time.deltaTime);
        }
    }
}