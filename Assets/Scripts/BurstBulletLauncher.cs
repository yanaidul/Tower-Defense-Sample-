using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstBulletLauncher : Launcher, ILauncher
{
    private Bullet _tempBurstBullet;
    [SerializeField] int _burstBulletCount = 35;

    protected override void UniqueLaunch(GameObjectPool gameObjectInPool)
    {
        for (int i = 0; i < _burstBulletCount; i++)
        {
            GameObject pooledGameObject = gameObjectInPool.GetPooledObject();
            if (pooledGameObject != null)
            {
                if (!pooledGameObject.TryGetComponent(out _tempBurstBullet)) return;
                _tempBurstBullet.SetEnemyTarget(_enemyDetector.FirstEnemy);

                pooledGameObject.transform.position = gameObject.transform.position;
                int randomizedOffsetZ = Random.Range(-45, 45);
                Vector3 targetRotation = _enemyDetector.FirstEnemy.transform.position - pooledGameObject.transform.position;
                float angle = Vector3.SignedAngle(pooledGameObject.transform.up, targetRotation, pooledGameObject.transform.forward);
                pooledGameObject.transform.Rotate(0, 0, angle + randomizedOffsetZ);
                pooledGameObject.SetActive(true);
            }
        }
    }
}
