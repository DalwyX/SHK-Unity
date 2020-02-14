using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _bonusSpeedModifier;
    [SerializeField] private float _bonusTime;
    private bool _isBonusActive;
    private float _bonusRemainingTime;

    private void Update()
    {
        Move();
        CheckBonus();
    }

    public void ActivateBonus()
    {
        _isBonusActive = true;
        _bonusRemainingTime = _bonusTime;
        _moveSpeed *= _bonusSpeedModifier;
    }

    public void DeactivateBonus()
    {
        _isBonusActive = true;
        _moveSpeed /= _bonusSpeedModifier;
    }

    private void Move()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var transition = _moveSpeed * Time.deltaTime * new Vector3(h, v);
        transform.Translate(transition);
    }

    private void CheckBonus()
    {
        if (_isBonusActive)
        {
            _bonusRemainingTime -= Time.deltaTime;
            if (_bonusRemainingTime < 0)
            {
                _isBonusActive = false;
                _moveSpeed /= _bonusSpeedModifier;
            }
        }
    }
}
