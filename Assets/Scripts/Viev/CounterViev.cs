using TMPro;
using UnityEngine;

public class CounterViev : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        _text.text = value.ToString("00:00");
    }
}
