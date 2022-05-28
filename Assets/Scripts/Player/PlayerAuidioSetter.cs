using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAuidioSetter : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.Moved += OnMoved;
    }

    private void OnDisable()
    {
        _player.Moved -= OnMoved;
    }

    private void OnMoved(bool isMoving)
    {
        if (isMoving)
        {
            if (_audio.isPlaying != true)
                _audio.Play();
        }
        else
        {
            _audio.Stop();
        }
    }
}
