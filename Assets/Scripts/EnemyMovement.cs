using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    [SerializeField] private WayPoint _currentWayPoint;
    public WayPoint CurrentWayPoint => _currentWayPoint;



    private void Update()
    {
        HandleMovementToNodes();
    }

    private void HandleMovementToNodes()
    {
        transform.position = Vector2.MoveTowards(transform.position, CurrentWayPoint.gameObject.transform.position, _movementSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, CurrentWayPoint.gameObject.transform.position) < 0.01f)
        {
            _currentWayPoint = CurrentWayPoint.NextWayPoint;
        }
    }

    public void SetWayPoint(WayPoint targetWayPoint)
    {
        _currentWayPoint = targetWayPoint;
        transform.position = CurrentWayPoint.transform.position;
    }
}
