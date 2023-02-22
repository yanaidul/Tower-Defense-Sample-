using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthElement : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health = 100;


    public void Damage(int damage)
    {
        _health -= damage;

        if (_health <= 0) gameObject.SetActive(false);
    }

    
}
