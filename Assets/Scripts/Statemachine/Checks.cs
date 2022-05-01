using System;
using UnityEngine;

public class Checks : MonoBehaviour
{
    const float GroundedRadius = .2f;

    private int _xInput;
    private bool _isJumping;
    private bool _isInteract;

    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _interactableCheck;

    public int XInput => _xInput;
    public bool IsJumping => _isJumping;

    public int FacingDirection { get; private set; } = 1;

    public bool IsInteract()
    {
        if (_isInteract)
        {
            _isInteract = false;
            return true;
        }

        return false;
    }

    public bool SetInteract() => _isInteract = true;

    public bool IsOnGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GroundedRadius, _whatIsGround);

        foreach (var collider in colliders)
            if (collider.gameObject != gameObject)
                return true;

        return false;
    }

    public bool TryInteract(out IInteractable interactable)
    {
        interactable = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_interactableCheck.position, .5f);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractable interactable1))
            {
                interactable = interactable1;
                return true;
            }
        }

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
