using UnityEngine;

public class SegmentViev : MonoBehaviour
{
    [SerializeField] private Segment _segment;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color[] _colors;

    private void OnEnable()
    {
        _segment.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(SegmentState arg0)
    {
        _renderer.color = _colors[(int)arg0];
    }

    private void OnDisable()
    {
        _segment.StateChanged -= OnStateChanged;
    }
}
