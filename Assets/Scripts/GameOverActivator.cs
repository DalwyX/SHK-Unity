using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GameOverActivator : MonoBehaviour
{
    private SpriteRenderer _sr;
    private List<Enemy> _enemies;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.enabled = false;
    }

    private void OnEnable()
    {
        _enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
        foreach (var enemy in _enemies)
        {
            enemy.EnemyDied += CheckGameOverCondition;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.EnemyDied -= CheckGameOverCondition;
        }
    }

    public void CheckGameOverCondition(Enemy diedEnemy)
    {
        _enemies.Remove(diedEnemy);
        if (_enemies.Count == 0)
        {
            ActivateGameOverScreen();
        }
    }

    private void ActivateGameOverScreen()
    {
        _sr.enabled = true;
    }
}
