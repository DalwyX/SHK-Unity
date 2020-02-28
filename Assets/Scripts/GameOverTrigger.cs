using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GameOverTrigger : MonoBehaviour
{
    private SpriteRenderer _gameOverScreen;
    private List<Enemy> _enemies;

    private void Awake()
    {
        _gameOverScreen = GetComponent<SpriteRenderer>();
        _gameOverScreen.enabled = false;
    }

    private void OnEnable()
    {
        _enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDied;
        }
    }

    public void OnEnemyDied(Enemy diedEnemy)
    {
        _enemies.Remove(diedEnemy);
        if (_enemies.Count == 0)
        {
            ActivateGameOverScreen();
        }
    }

    private void ActivateGameOverScreen()
    {
        _gameOverScreen.enabled = true;
    }
}
