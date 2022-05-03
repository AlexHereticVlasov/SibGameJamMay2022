using UnityEngine;

public class CheckPointViev : MonoBehaviour
{
    [SerializeField] private CheckPoint _checkPoint;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteBean bean;

    private void OnEnable()
    {
        _checkPoint.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(CheckPointState arg0)
    {
        _renderer.sprite = bean[(int)arg0];
    }

    private void OnDisable()
    {
        _checkPoint.StateChanged -= OnStateChanged;
    }
}
