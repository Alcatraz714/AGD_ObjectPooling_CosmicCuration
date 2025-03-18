using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView bulletView_r;
        private BulletScriptableObject bulletScriptableObject_r;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();


        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            bulletView_r = bulletView;
            bulletScriptableObject_r = bulletScriptableObject;
        }

        public BulletController GetBullet()
        {
            if (pooledBullets.Count >0)
            {
                PooledBullet pooledBullet = pooledBullets.Find(item => !item.isUsed);
                if (pooledBullet != null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.Bullet;
                }
            }
            return CreateNewPooledBullet();
        }

        public void ReturnBulletToPool(BulletController returnedBullet)
        {
            PooledBullet pooledBullet = pooledBullets.Find(item => item.Bullet.Equals(returnedBullet));
            pooledBullet.isUsed = false;
        }

        private BulletController CreateNewPooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.Bullet = new BulletController(bulletView_r, bulletScriptableObject_r);
            pooledBullet.isUsed = true;
            pooledBullets.Add(pooledBullet);
            return pooledBullet.Bullet;
        }

        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }
}

