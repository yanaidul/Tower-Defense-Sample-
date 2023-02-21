using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomebaseCollision : MonoBehaviour
{
    [SerializeField] string _enemyTag = "Enemy";
    [SerializeField] int damageToBase = 1;

    private IDamageable _damageable;

    private void Awake()
    {
        _damageable = GetComponent<IDamageable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(_enemyTag))
        {
            _damageable.Damage(damageToBase);
            collision.gameObject.SetActive(false);
        }
    }
}
