using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDuration;
    [SerializeField] private WayPoint _startingWayPoint;

    private EnemyMovement _tempEnemyMovement;

    private void Start()
    {
        StartCoroutine(SpawnEnemyOnDelay(_spawnDuration));
    }
    private void SpawnEnemy()
    {
        GameObject enemy = EnemyObjectPool.SharedInstance.GetPooledObject();
        if (enemy != null)
        {
            if (!enemy.TryGetComponent(out _tempEnemyMovement)) return;
            _tempEnemyMovement.SetWayPoint(_startingWayPoint);

            enemy.transform.position = gameObject.transform.position;
            enemy.transform.rotation = gameObject.transform.rotation;
            enemy.SetActive(true);
        }
    }

    IEnumerator SpawnEnemyOnDelay(float spawnDuration)
    {
        yield return new WaitForSeconds(spawnDuration);
        SpawnEnemy();
        StartCoroutine(SpawnEnemyOnDelay(spawnDuration));
    }

}
