using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] float _rotationSpeed;
    [SerializeField] string _enemyTag = "Enemy";
    public GameObject FirstEnemy { 
        get
        {
            if(_enemies.Count > 0)
            {
                return _enemies[0];
            }
            return null;
        }
    }

    public bool IsEnemyWithinRange
    {
        get
        {
            if (_enemies.Count > 0)
            {
                return true;
            }
            return false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(_enemyTag))
        {
            _enemies.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out EnemyMovement enemy)) return;
        _enemies.Remove(enemy.gameObject);
    }
}
