using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    public float LookDirection { get; private set; }

    public UnityAction<bool> Moved;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        LookDirection = 1;
    }

    private void Update()
    {
        if (_joystick.Horizontal != 0)
        {
            LookDirection = CalculateLookDirection(_joystick.Horizontal);
        }

        var targetVector = _joystick.Direction;

        _rigidbody.velocity = new Vector2(_joystick.Horizontal, _joystick.Vertical) * _speed;
         
        Moved?.Invoke(targetVector != Vector2.zero);
    }

    private void MoveTowardTarget(Vector2 targetVector)
    {
        var speed = _speed * Time.deltaTime;

        _rigidbody.MovePosition(_rigidbody.position + targetVector * _speed * Time.deltaTime);
    }

    private float CalculateLookDirection(float direction)
    {
        var lastDirection = direction > 0 ? 1 : -1;

        return lastDirection;
    }
}
