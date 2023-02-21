using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField] EnemyDetector _enemyDetector;

    [SerializeField] float _rotationSpeed;

    private void Update()
    {
        HandleTowerRotation();
    }

    private void HandleTowerRotation()
    {
        if (!_enemyDetector.IsEnemyWithinRange) return;
        Vector3 targetRotation = _enemyDetector.FirstEnemy.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, targetRotation, transform.forward);
        transform.Rotate(0, 0, angle);

    }
}
