using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _walkingAreaRadius = 4f;
    private Vector3 _target;

    public event Action<Enemy> Died;

    private void Start()
    {
        CreateNewTarget();
    }

    private void Update()
    {
        var delta = _moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target, delta);

        if (transform.position == _target)
            CreateNewTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.ActivateBonus();
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }

    public void CreateNewTarget()
    {
        _target = UnityEngine.Random.insideUnitCircle * _walkingAreaRadius;
    }
}
