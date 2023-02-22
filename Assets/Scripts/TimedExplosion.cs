using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedExplosion : Explosion
{
    public override void Explode()
    {
        base.Explode();
        StartCoroutine(OnExplosion(_timeUntilExplosionDissappear));
    }

    IEnumerator OnExplosion(float _timeUntilExplosionDissappear)
    {
        yield return new WaitForSeconds(_timeUntilExplosionDissappear);
        _explosionParticle.gameObject.SetActive(false);
        _boxCollider2D.size = new Vector2(1, 1);
        gameObject.SetActive(false);
    }
}
