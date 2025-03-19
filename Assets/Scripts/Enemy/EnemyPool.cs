using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView enemyView_r;
        private EnemyData enemyData_r;
        private List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();


        public EnemyPool(EnemyView enemyView, EnemyData enemyData)
        {
            enemyView_r = enemyView;
            enemyData_r = enemyData;
        }

        public EnemyController GetEnemy()
        {
            if (pooledEnemies.Count >0)
            {
                PooledEnemy pooledEnemy = pooledEnemies.Find(item => !item.isUsed);
                if (pooledEnemy != null)
                {
                    pooledEnemy.isUsed = true;
                    return pooledEnemy.Enemy;
                }
            }
            return CreateNewPooledEnemy();
        }

        public void ReturnEnemyToPool(EnemyController returnedEnemy)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(item => item.Enemy.Equals(returnedEnemy));
            pooledEnemy.isUsed = false;
        }

        private EnemyController CreateNewPooledEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.Enemy = new EnemyController(enemyView_r, enemyData_r);
            pooledEnemy.isUsed = true; // is now being used in active scene
            pooledEnemies.Add(pooledEnemy);
            return pooledEnemy.Enemy;
        }

        public class PooledEnemy
        {
            public EnemyController Enemy;
            public bool isUsed;
        }
    }
}

