using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Launcher : MonoBehaviour, ILauncher
{
    [SerializeField] protected EnemyDetector _enemyDetector;

    public void Launch()
    {
        if (!_enemyDetector.IsEnemyWithinRange) return;
        if (!transform.parent.TryGetComponent(out GameObjectPool gameObjectInPool)) return;
        UniqueLaunch(gameObjectInPool);
    }

    protected abstract void UniqueLaunch(GameObjectPool gameObjectInPool);
}
