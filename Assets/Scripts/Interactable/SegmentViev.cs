using UnityEngine;

public class SegmentViev : MonoBehaviour
{
    [SerializeField] private Segment _segment;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteBean _bean;

    private void OnEnable()
    {
        _segment.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(SegmentState arg0)
    {
        _renderer.sprite = _bean[(int)arg0];
    }

    private void OnDisable()
    {
        _segment.StateChanged -= OnStateChanged;
    }
}
