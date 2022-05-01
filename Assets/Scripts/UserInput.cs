using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private CharacterController2D _playerMovement;
    [SerializeField] private float _speed;

    private float _horizontal;
    private bool _isJumping;
    private bool _isCrouching;

    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_horizontal * _speed * Time.deltaTime, _isCrouching, _isJumping);
        _isJumping = false;
    }

    private void ReadInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            _isCrouching = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Interact");
            Debug.Log(_playerMovement.transform.localScale.x);
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
