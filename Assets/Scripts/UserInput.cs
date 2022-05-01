using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private Checks _checks;

    private float _horizontal;

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            _checks.SetInteract();
        }
    }
}

