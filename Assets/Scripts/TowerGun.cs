using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGun : MonoBehaviour
{
    private ILauncher _launcher;

    [SerializeField] EnemyDetector _enemyDetector;

    [SerializeField] float _fireRefreshRate = 1f;
    private float _nextFireTime;

    private void Awake()
    {
        _launcher = GetComponent<ILauncher>();
    }

    private void Update()
    {
        if(CanFire() && _enemyDetector.IsEnemyWithinRange)
        {
            FireWeapon();
        }
    }

    private bool CanFire()
    {
        return Time.time >= _nextFireTime;
    }

    private void FireWeapon()
    {
        _nextFireTime = Time.time + _fireRefreshRate;
        _launcher.Launch();
    }


}
