using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _projectileSpeed;
    [SerializeField] int _bulletDamage;
    [SerializeField] string _enemyTag = "Enemy";
    private EnemyHealth _tempEnemyHealth;

    private GameObject _target;


    private void Update()
    {
        if (_target == null) return;
         transform.position=Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * _projectileSpeed);
    }

    public void SetEnemyTarget(GameObject target)
    {
        _target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(_enemyTag))
        {
            if (!collision.TryGetComponent(out _tempEnemyHealth)) return;
            _tempEnemyHealth.Damage(_bulletDamage);
            gameObject.SetActive(false);
        }
    }


}
