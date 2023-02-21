using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstBulletLauncher : MonoBehaviour, ILauncher
{
    [SerializeField] EnemyDetector _enemyDetector;
    private BurstBullet _tempBurstBullet;


    public void Launch(TowerGun towerGun)
    {
        if (!_enemyDetector.IsEnemyWithinRange) return;
        for (int i = 0; i < 35; i++)
        {
            GameObject burstBullet = BurstBulletObjectPool.SharedInstance.GetPooledObject();
            if (burstBullet != null)
            {
                if (!burstBullet.TryGetComponent(out _tempBurstBullet)) return;
                _tempBurstBullet.SetEnemyTarget(_enemyDetector.FirstEnemy);

                burstBullet.transform.position = gameObject.transform.position;
                int randomizedOffsetZ = Random.Range(-45, 45);
                Vector3 targetRotation = _enemyDetector.FirstEnemy.transform.position - burstBullet.transform.position;
                float angle = Vector3.SignedAngle(burstBullet.transform.up, targetRotation, burstBullet.transform.forward);
                burstBullet.transform.Rotate(0, 0, angle+randomizedOffsetZ);
                burstBullet.SetActive(true);
            }
        }
        

    }
}
