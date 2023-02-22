using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] protected GameObject _explosionParticle;
    [SerializeField] protected BoxCollider2D _boxCollider2D;
    [SerializeField] protected float _timeUntilExplosionDissappear = 0.2f;
    [SerializeField] protected float _boxColliderSizeAfterExplosion = 17;

    public virtual void Explode()
    {
        _explosionParticle.gameObject.SetActive(true);
        _boxCollider2D.size = new Vector2(_boxColliderSizeAfterExplosion, _boxColliderSizeAfterExplosion);
    }

    
}
