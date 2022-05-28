using UnityEngine;

public class PlayerAnimationSetter : MonoBehaviour, IAnimationSetter
{
    [Header("Links")]
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;

    [Header("Particles")]
    [SerializeField] private ParticleSystem _runParticles;

    private string _currentAnimationState;

    private void OnEnable()
    {
        _playerMovement.Moved += OnMoved;
    }

    private void OnDisable()
    {
        _playerMovement.Moved -= OnMoved;
    }

    private void Update()
    {
        transform.localScale = new Vector2(_playerMovement.LookDirection, 1);
    }

    public void SetAnimationState(string newState)
    {
        if (_currentAnimationState == newState)
            return;

        _animator.Play(newState);

        _currentAnimationState = newState;
    }

    private void OnMoved(bool isMoving)
    {
        if (isMoving)
        {
            SetAnimationState(AnimationsState.Run.ToString());

            if (_runParticles.isPlaying != true)
            {
                _runParticles.Play();
            }
        }
        else
        {
            SetAnimationState(AnimationsState.Idle.ToString());
            _runParticles.Stop();
        }
    }
}


public enum AnimationsState
{
    Idle,
    Run
}