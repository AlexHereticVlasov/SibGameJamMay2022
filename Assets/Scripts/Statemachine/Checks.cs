using System;
using UnityEngine;

public class Checks : MonoBehaviour
{
    const float GroundedRadius = .2f;

    private int _xInput;
    private bool _isJumping;

    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;

    public int XInput => _xInput;
    public bool IsJumping => _isJumping;
    public int FacingDirection { get; private set; } = 1;

    public bool IsOnGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GroundedRadius, _whatIsGround);

        foreach (var collider in colliders)
            if (collider.gameObject != gameObject)
                return true;

        return false;
    }

    public void SetXInput(int value) => _xInput = value;

    public void SetIsJumping(bool value) => _isJumping = value;

    internal void CheckIfShoudFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
            Flip();
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0, 180, 0);
    }
}
