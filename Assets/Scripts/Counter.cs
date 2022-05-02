using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private Player _player;

    private float _max = 15;
    private bool _isInside;
    private bool _wasWarped;

    public event UnityAction<float> ValueChanged;

    private void OnEnable()
    {
        //_player.Dead += OnDead;
        _player.EnterInSaveZone += OnEnterInSaveZone;
        _player.ExitFromSaveZone += OnExitFromSaveZone;
        _player.Warped += OnWarped;
    }

    

    private void Start() => ResetValue();

    private void Update()
    {
        if (_isInside || _wasWarped) return;

        if (_value >= 0)
        {
            _value -= Time.deltaTime;
            ValueChanged?.Invoke(_value);
        }
        else
        {
            _wasWarped = true;
            Debug.Log("Time is Running out");
            _player.Die();
        }
    }

    private void OnDisable()
    {
        //_player.Dead -= OnDead;
        _player.EnterInSaveZone -= OnEnterInSaveZone;
        _player.ExitFromSaveZone -= OnExitFromSaveZone;
        _player.Warped -= OnWarped;
    }

    //private void OnDead() => ResetValue();

    private void OnWarped()
    {
        ResetValue();
        _wasWarped = false;
    }

    private void OnExitFromSaveZone()
    {
        _isInside = false;
    }

    private void OnEnterInSaveZone(SaveZone saveZone)
    {
        _isInside = true;
        ResetValue();
    }

    private void ResetValue()
    {
        _value = _max;
        ValueChanged?.Invoke(_value);
    }

    private void IncreaseValue(float value) => _value = Mathf.Clamp(_value + value, 0, _max);
}
