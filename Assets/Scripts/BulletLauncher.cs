using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : Launcher,ILauncher
{
    private Bullet _tempBullet;

    protected override void UniqueLaunch(GameObjectPool gameObjectInPool)
    {
        GameObject pooledGameObject = gameObjectInPool.GetPooledObject();

        if (pooledGameObject != null)
        {
            if (!pooledGameObject.TryGetComponent(out _tempBullet)) return;
            _tempBullet.SetEnemyTarget(_enemyDetector.FirstEnemy);

            pooledGameObject.transform.position = gameObject.transform.position;
            Vector3 targetRotation = _enemyDetector.FirstEnemy.transform.position - pooledGameObject.transform.position;
            float angle = Vector3.SignedAngle(pooledGameObject.transform.up, targetRotation, pooledGameObject.transform.forward);
            pooledGameObject.transform.Rotate(0, 0, angle);
            pooledGameObject.SetActive(true);
        }
    }
}
