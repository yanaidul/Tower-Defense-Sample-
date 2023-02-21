using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour, ILauncher
{
    [SerializeField] EnemyDetector _enemyDetector;
    private Missile _tempMissile;


    public void Launch(TowerGun towerGun)
    {
        if (!_enemyDetector.IsEnemyWithinRange) return;
        GameObject missile = MissileObjectPool.SharedInstance.GetPooledObject();
        if (missile != null)
        {
            if (!missile.TryGetComponent(out _tempMissile)) return;
            _tempMissile.SetEnemyTarget(_enemyDetector.FirstEnemy);

            missile.transform.position = gameObject.transform.position;
            Vector3 targetRotation = _enemyDetector.FirstEnemy.transform.position - missile.transform.position;
            float angle = Vector3.SignedAngle(missile.transform.up, targetRotation, missile.transform.forward);
            missile.transform.Rotate(0, 0, angle);
            missile.SetActive(true);
        }

    }
}
