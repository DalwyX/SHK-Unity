using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _walkingAreaRadius = 4f;
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

    public void SetNewDestination()
    {
        _currentTarget = Random.insideUnitCircle * _walkingAreaRadius;
    }
}
