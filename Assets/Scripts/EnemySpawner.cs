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
        if (TryGetComponent(out GameObjectPool gameObjectInPool))
        {
            GameObject pooledGameObject = gameObjectInPool.GetPooledObject();
            if (pooledGameObject != null)
            {
                if (!pooledGameObject.TryGetComponent(out _tempEnemyMovement)) return;
                _tempEnemyMovement.SetWayPoint(_startingWayPoint);

                pooledGameObject.transform.position = gameObject.transform.position;
                pooledGameObject.transform.rotation = gameObject.transform.rotation;
                pooledGameObject.SetActive(true);
            }
        }
        
    }

    IEnumerator SpawnEnemyOnDelay(float spawnDuration)
    {
        yield return new WaitForSeconds(spawnDuration);
        SpawnEnemy();
        StartCoroutine(SpawnEnemyOnDelay(spawnDuration));
    }

}
