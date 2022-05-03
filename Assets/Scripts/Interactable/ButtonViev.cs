using UnityEngine;

public class ButtonViev : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteBean _bean;

    private void OnEnable()
    {
        _button.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(ButtonState arg0)
    {
        _renderer.sprite = _bean[(int)arg0];
    }

    private void OnDisable()
    {
        _button.StateChanged -= OnStateChanged;
    }
}

