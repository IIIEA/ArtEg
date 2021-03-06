using UnityEngine;
using DG.Tweening;

public class DanceTrees : MonoBehaviour
{
    [SerializeField] private float _scaleX1;
    [SerializeField] private float _scaleY1;
    [SerializeField] private float _duration1;
    [SerializeField] private float _duration2;

    private Vector3 _startScale;

    private void Start()
    {
        _startScale = transform.localScale;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScaleX(_scaleX1, _duration1));
        sequence.Append(transform.DOScaleY(_scaleY1, _duration1));

        sequence.Append(transform.DOScaleY(_startScale.y, _duration1));
        sequence.Append(transform.DOScaleX(_startScale.x, _duration2));

        sequence.SetLoops(-1);
    }
}
