using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour,ILauncher
{
    [SerializeField] EnemyDetector _enemyDetector;
    private Bullet _tempBullet;


    public void Launch(TowerGun towerGun)
    {
        if (!_enemyDetector.IsEnemyWithinRange) return;
        GameObject bullet = BulletObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            if (!bullet.TryGetComponent(out _tempBullet)) return;
            _tempBullet.SetEnemyTarget(_enemyDetector.FirstEnemy);

            bullet.transform.position = gameObject.transform.position;
            Vector3 targetRotation = _enemyDetector.FirstEnemy.transform.position - bullet.transform.position;
            float angle = Vector3.SignedAngle(bullet.transform.up, targetRotation, bullet.transform.forward);
            bullet.transform.Rotate(0, 0, angle);
            bullet.SetActive(true);
        }

    }
}
