using System;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _bonusSpeedModifier;
    [SerializeField] private float _bonusTime;

    private void Update()
    {
        Move();
    }

    public async void ActivateBonus()
    {
        _moveSpeed *= _bonusSpeedModifier;
        await Task.Delay(TimeSpan.FromSeconds(_bonusTime));
        _moveSpeed /= _bonusSpeedModifier;
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var transition = _moveSpeed * Time.deltaTime * new Vector3(horizontal, vertical);
        transform.Translate(transition);
    }
}
