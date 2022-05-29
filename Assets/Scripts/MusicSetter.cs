using UnityEngine;
using DG.Tweening;

public class MusicSetter : MonoBehaviour
{
    [SerializeField] private AudioSource _backMusic;

    private float _startVolume;

    private void Start()
    {
        _startVolume = _backMusic.volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteraction>() != null)
        {
            _backMusic.DOFade(0, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteraction>() != null)
        {
            _backMusic.DOFade(_startVolume, 0.5f);
        }
    }
}
