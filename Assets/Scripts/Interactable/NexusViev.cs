using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusViev : MonoBehaviour
{
    [SerializeField] private Nexus _nexus;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color[] _colors;

    private void OnEnable()
    {
        _nexus.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(NexusState arg0)
    {
        _renderer.color = _colors[(int)arg0];
    }

    private void OnDisable()
    {
        _nexus.StateChanged -= OnStateChanged;
    }
}
