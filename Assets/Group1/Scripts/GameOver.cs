using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private Player _player;

    private Enemy[] _enemies;
    private int _enemiesCounter;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();

        _enemiesCounter = 0;
        foreach (var enemy in _enemies)
        {
            enemy.EnemyDied += OnEnemyDied;
            _enemiesCounter++;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
            enemy.EnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _enemiesCounter--;

        if(_enemiesCounter <= 0)
        {
            _endGameScreen.SetActive(true);
            _player.enabled = false;
        }
    }
}
