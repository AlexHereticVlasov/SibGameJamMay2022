using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusViev : MonoBehaviour
{
    [SerializeField] private Nexus _nexus;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteBean _bean;

    private void OnEnable()
    {
        _nexus.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(NexusState arg0)
    {
        _renderer.sprite = _bean[(int)arg0];
    }

    private void OnDisable()
    {
        _nexus.StateChanged -= OnStateChanged;
    }
}
