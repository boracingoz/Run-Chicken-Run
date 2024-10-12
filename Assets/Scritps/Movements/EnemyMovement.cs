using Controller;
using System.Collections;
using UnityEngine;

namespace Movements
{
    public class EnemyMovement
    {
        private EnemyController _enemyController;

        public EnemyMovement(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void FixedTick()
        {
            _enemyController.transform.Translate(Vector3.back * _enemyController._currentMoveSpeed * Time.deltaTime);
        }
    }
}