using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _waypointsParent;
    [SerializeField] private float _speed = 2f;

    private int _currentWaypointIndex = 0;
    private Transform[] _waypoints;

    private void Start()
    {
        _waypoints = new Transform[_waypointsParent.childCount];
        for (int i = 0; i < _waypointsParent.childCount; i++)
        {
            _waypoints[i] = _waypointsParent.GetChild(i);
        }
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - _waypoints[_currentWaypointIndex].position.x) < 0.01f)
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;

        var movementDirection = _waypoints[_currentWaypointIndex].position - transform.position;
        movementDirection.y = 0;
        transform.position += movementDirection.normalized * (_speed * Time.deltaTime);
        SetRotationByMoveDirection(movementDirection);
    }

    private void SetRotationByMoveDirection(Vector3 movementDirection)
    {
        if(movementDirection.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}