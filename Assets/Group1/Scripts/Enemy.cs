using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _targetRadiusSize = 4;
    [SerializeField] private EndScreenOpener _endScreenOpener;

    private static int _enemiesCounter;

    private Vector3 _targetPosition;

    private void Start()
    {
        _enemiesCounter++;
        _targetPosition = Random.insideUnitCircle * _targetRadiusSize;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (transform.position == _targetPosition)
            _targetPosition = Random.insideUnitCircle * _targetRadiusSize;
    }

    private void OnDestroy()
    {
        _enemiesCounter--;
        if (_enemiesCounter <= 0)
            _endScreenOpener.ShowEndGameScreen();
    }
}
