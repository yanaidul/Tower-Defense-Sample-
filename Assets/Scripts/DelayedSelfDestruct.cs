using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSelfDestruct : MonoBehaviour
{
    [SerializeField] float _selfDestructDuration = 2.5f;
    private void Start()
    {
        StartCoroutine(OnSelfDestruct(_selfDestructDuration));
    }
    IEnumerator OnSelfDestruct(float selfDestructDuration)
    {
        yield return new WaitForSeconds(selfDestructDuration);
        gameObject.SetActive(false);
    }
}
