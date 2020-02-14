using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _walkingAreaRadius = 4f;
    public event Action<Enemy> EnemyDied;
    private Vector3 _currentTarget;

    private void Start()
    {
        SetNewDestination();
    }

    private void Update()
    {
        var maxDistanceDelta = _moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, maxDistanceDelta);

        if (transform.position == _currentTarget)
            SetNewDestination();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.ActivateBonus();
            EnemyDied?.Invoke(this);
            Destroy(gameObject);
        }
    }

    public void SetNewDestination()
    {
        _currentTarget = UnityEngine.Random.insideUnitCircle * _walkingAreaRadius;
    }
}
