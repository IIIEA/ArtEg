using UnityEngine;
using UnityEngine.UI;

public class BlinkColor : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color[] _colors;

    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 0.3f)
        {
            _timer = 0;
            _image.color = GetRandomColor(_colors);
        }
    }

    private Color GetRandomColor(Color[] colors)
    {
        var index = Random.Range(0, colors.Length);

        if(_image.color == colors[index])
        {
            index = Random.Range(0, colors.Length);
        }

        return colors[index];
    }
}
