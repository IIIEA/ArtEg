using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;

    public float LookDirection { get; private set; }

    public UnityAction<bool> Moved;

    private void Start()
    {
        LookDirection = 1;
    }

    private void Update()
    {
        if (_joystick.Horizontal != 0)
        {
            LookDirection = CalculateLookDirection(_joystick.Horizontal);
        }

        var targetVector = _joystick.Direction;

        MoveTowardTarget(targetVector);

        Moved?.Invoke(targetVector != Vector2.zero);
    }

    private void MoveTowardTarget(Vector3 targetVector)
    {
        var speed = _speed * Time.deltaTime;
        transform.Translate(targetVector * speed);
    }

    private float CalculateLookDirection(float direction)
    {
        var lastDirection = direction > 0 ? 1 : -1;

        return lastDirection;
    }
}
