using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float _projectileSpeed;
    [SerializeField] int _projectileDamage;
    [SerializeField] string _enemyTag = "Enemy";
 
    private HealthElement _tempEnemyHealth;
    private GameObject _target;

    [SerializeField] Explosion _explosion;
    private void Update()
    {
        if (_target == null) return;
        transform.Translate(Vector3.up * _projectileSpeed * Time.deltaTime, Space.Self);
    }

    public void SetEnemyTarget(GameObject target)
    {
        _target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_enemyTag))
        {
            if (!collision.TryGetComponent(out _tempEnemyHealth)) return;
            _tempEnemyHealth.Damage(_projectileDamage);
            _explosion.Explode();
        }
    }

    
}
