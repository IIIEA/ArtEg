using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField] private int _sortingOrderBase;
    [SerializeField] private int _offset = 0;
    [SerializeField] private bool _runOnlyOnce = false;

    private Renderer _renderer;
    private float _timer;
    private float _timerMax = 0.1f;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        _timer -= Time.deltaTime;

        if(_timer <= 0)
        {
            _timer = _timerMax;
            _renderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y - _offset);

            if (_runOnlyOnce)
            {
                Destroy(this);
            }
        }
    }
}
