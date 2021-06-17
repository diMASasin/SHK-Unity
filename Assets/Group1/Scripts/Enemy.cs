using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _locationRadius = 4;

    private Vector3 _targetPosition;

    public event UnityAction<Enemy> EnemyDied;

    private void Start()
    {   
        SetTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (transform.position == _targetPosition)
            SetTargetPosition();
    }

    public void Die()
    {
        EnemyDied?.Invoke(this);
        Destroy(gameObject);
    }

    private void SetTargetPosition()
    {
        _targetPosition = Random.insideUnitCircle * _locationRadius;
    }
}
