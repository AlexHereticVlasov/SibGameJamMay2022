using UnityEngine;

public class DoorViev : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color[] _colors;

    private void OnEnable()
    {
        _door.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(DoorState arg0)
    {
        _renderer.color = _colors[(int)arg0];
    }

    private void OnDisable()
    {
        _door.StateChanged -= OnStateChanged;
    }
}

