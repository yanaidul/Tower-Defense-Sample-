using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private WayPoint _nextWayPoint;
    public WayPoint NextWayPoint => _nextWayPoint;
}
