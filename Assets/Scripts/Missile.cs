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

    [Header("Explosion Related Components")]
    [SerializeField] GameObject _explosionParticle;
    [SerializeField] BoxCollider2D _boxCollider2D;
    [SerializeField] float _timeUntilExplosionDissappear;
    [SerializeField] float _boxColliderSizeAfterExplosion;



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
            StartCoroutine(OnExplosion(_timeUntilExplosionDissappear));
            
        }
    }

    IEnumerator OnExplosion(float _timeUntilExplosionDissappear)
    {
        _explosionParticle.gameObject.SetActive(true);
        _boxCollider2D.size = new Vector2(_boxColliderSizeAfterExplosion, _boxColliderSizeAfterExplosion);
        yield return new WaitForSeconds(_timeUntilExplosionDissappear);
        _explosionParticle.gameObject.SetActive(false);
        _boxCollider2D.size = new Vector2(1, 1);
        gameObject.SetActive(false);
    }
}
