using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }
}

