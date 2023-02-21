using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomebaseHealth : MonoBehaviour,IDamageable
{
    [SerializeField] int _baseHealth = 5;

    public void Damage(int damage)
    {
        _baseHealth -= damage;

        if (_baseHealth <= 0) gameObject.SetActive(false);
    }

    
}
