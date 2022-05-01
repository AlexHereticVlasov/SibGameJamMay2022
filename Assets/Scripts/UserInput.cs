using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private CharacterController2D _playerMovement;
    [SerializeField] private Checks _checks;
    [SerializeField] private float _speed;

    private float _horizontal;
    private bool _isJumping;
    private bool _isCrouching;

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _checks.SetXInput((int)_horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _checks.SetIsJumping(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _checks.SetIsJumping(false);
        }

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    _isCrouching = true;
        //}
        //else if (Input.GetKeyUp(KeyCode.S))
        //{
        //    _isCrouching = false;
        //}

        if (Input.GetKeyDown(KeyCode.F))
        {
            _checks.SetInteract();
        }
    }
}

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        CalculateHashes();
    }

    private void CalculateHashes()
    {
        
    }
}
